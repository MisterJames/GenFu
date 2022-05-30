﻿namespace GenFu.Tests.TestEntities;

using System;

public class Nullables
{
    public DateTime? NullableDateTime { get; set; }
    public int? NullableInt { get; set; }
    public uint? NullableUInt { get; set; }
    public double? NullableDouble { get; set; }
    public decimal? NullableDecimal { get; set; }
    public long? NullableLong { get; set; }
    public ulong? NullableULong { get; set; }
    public short? NullableShort { get; set; }
    public bool? NullableBoolean { get; set; }
    public char? NullableChar { get; set; }
    public PropertyType? NullableEnum { get; set; }
}
