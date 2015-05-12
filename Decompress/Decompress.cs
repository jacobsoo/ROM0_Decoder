using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Decomp
{
    public Decomp()
    {

    }

    public Int32 get_bits(LZS_State state, int num)
    {
	    while (state.bitcnt < num) {
            state.bitbuf = (state.bitbuf << 8) | state.data[state.src++];
            state.bitcnt += 8;
	    }
        state.bitcnt -= num;
	    return (state.bitbuf>> state.bitcnt) & ((1 << num) -1);
    }

    
    public Int32 get_len(LZS_State state)
    {
	    Int32 bits;
        Int32 length = 2;

	    do {
		    bits = get_bits(state, 2);
		    length += bits;
	    } while ((bits == 3) && (length < 8));

	    if (length == 8) {
		    do {
			    bits = get_bits(state, 4);
			    length += bits;
		    } while (bits == 15);
	    }

	    return length;
    }

    public byte[] unpack(byte[] data)
    {
        int i = 0;
        LZS_State state = new LZS_State();
        state.data = data;
        state.dstData = new byte[65536];
	    while (true) {
            if (state.srcblkstart ==state.src)
			    state.src += 4;
            Int32 tag = get_bits(state, 1);
            if (tag == 0)
            {
                state.dstData[state.dst++] = (byte)get_bits(state, 8);
            }
            else
            {
                tag = get_bits(state, 1);
                Int32 offset = get_bits(state, (tag == 1) ? 7 : 11);

                if (tag == 1 && offset == 0)
                {
                    Int32 cnt = state.bitcnt;
                    Int32 tmp = get_bits(state, cnt);

                    state.srcblkstart = state.src;
                    state.dstblkstart = state.dst;

                    if (state.src >= data.Length)
                        break;

                    continue;
                }
                
                int dict = state.dst - offset;
                int len = get_len(state);

                while (len-- > 0)
                {
                    if(dict > 0)
                        state.dstData[state.dst++] = state.dstData[dict++];
                    if (state.dst >= 65536)
                        break;
                }
                if (state.dst >= 65536)
                    break;
            }
        }
        return state.dstData;
    }
}