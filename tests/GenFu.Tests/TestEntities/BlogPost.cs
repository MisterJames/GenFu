namespace GenFu.Tests.TestEntities;

using System;
using System.Collections.Generic;

internal class BlogPost
{
    public int BlogPostId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public BlogTypeEnum Type { get; set; }
    public virtual ICollection<BlogComment> Comments { get; set; }
    public DateTime CreateDate { get; set; }
    public ICollection<string> Tags { get; set; }

    public BlogPost()
    {
        Tags = new HashSet<string>();
    }
}

internal class BlogComment
{
    public int BlogCommentId { get; set; }
    public string Comment { get; set; }
    public string Username { get; set; }
    public DateTime CommentDate { get; set; }
}

internal class ColourfulBlogComment : BlogComment
{
    public string Colour { get; set; }
}

internal class DirtyBlogComment : BlogComment
{
    public int DirtFactor { get; set; }
}

internal class BlogCommenter
{
    public int BlogCommenterId { get; set; }
    public string NullName { get { return null; } }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class EnumExample
{
    public ByteEnum Byte { get; set; }
    public ShortEnum Short { get; set; }
    public IntEnum Int { get; set; }
    public LongEnum Long { get; set; }
    public SByteEnum SByte { get; set; }
    public UShortEnum UShort { get; set; }
    public UIntEnum UInt { get; set; }
    public ULongEnum ULong { get; set; }
}

public enum ByteEnum : byte
{
    A = 1,
    B = 2,
    C = 4
}

public enum ShortEnum : short
{
    A = 1,
    B = 2,
    C = 4
}

public enum IntEnum : int
{
    A = 1,
    B = 2,
    C = 4
}

public enum LongEnum : long
{
    A = 1,
    B = 2,
    C = 4
}

public enum SByteEnum : sbyte
{
    A = 1,
    B = 2,
    C = 4
}
public enum UShortEnum : ushort
{
    A = 1,
    B = 2,
    C = 4
}
public enum UIntEnum : uint
{
    A = 1,
    B = 2,
    C = 4
}

public enum ULongEnum : ulong
{
    A = 1,
    B = 2,
    C = 4
}
