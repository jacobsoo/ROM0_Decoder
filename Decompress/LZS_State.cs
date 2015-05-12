using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LZS_State
{
    public byte[] data;
    public int src = 0;
    public int srcblkstart = 0;
    public int srcsize;
    
    public byte[] dstData;
    public int dst = 0;
    public int dstblkstart = 0;
    public int dstsize;

    public int bitbuf = 0;
    public int bitcnt = 0;
}
