using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

public class ROM
{

    public ROM()
    {
    }
        
    public byte[] openFile(String filename)
    {
        byte[] bytes = null;

        bytes = System.IO.File.ReadAllBytes(filename);
        return bytes;
    }

    public ROM_Header getROMHeader(String filename)
    {
        byte[] arr = new byte[16];
        byte[] raw = openFile(filename);
        int k = 0;
        ROM_Header romHeader = null;
        for (int i = 0x202E; i < 0x202E + 0xF; i++)
        {
            arr[k++] =raw[i];
        }
        string result = System.Text.ASCIIEncoding.ASCII.GetString(arr);

        if (result.StartsWith("autoexec.net"))
        {
            Int16 size = (Int16)BitConverter.ToUInt16(raw, 0x202A);
            Int16 offset = (Int16)BitConverter.ToUInt16(raw, 0x202C);
            byte[] data = new byte[IPAddress.HostToNetworkOrder(size)];
            for (int i = 0; i < IPAddress.HostToNetworkOrder(size); i++)
            {
                data[i] = raw[i + IPAddress.HostToNetworkOrder(offset) + 8192];
            }
            romHeader = new ROM_Header(IPAddress.HostToNetworkOrder(offset), IPAddress.HostToNetworkOrder(size), result, data);
        }
        return romHeader;
    }
}
