using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ROM_Header
{
    private Int16 offset;
    private Int16 size;
    private String name;
    public byte[] data;

    public ROM_Header(Int16 offset, Int16 size, String name, byte[] data)
    {
        this.offset = offset;
        this.size = size;
        this.name = name;
        this.data = data;
    }

    public Int16 getOffset()
    {
        return offset;
    }
    public Int16 getSize()
    {
        return size;
    }
    public String getName()
    {
        return name;
    }
}
