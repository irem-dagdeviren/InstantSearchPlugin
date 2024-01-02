﻿// Decompiled with JetBrains decompiler
// Type: Nop.Plugin.InstantSearch.Dotless.Loggers.NullLogger
// Assembly: Nop.Plugin.InstantSearch.Dotless, Version=1.6.7.0, Culture=neutral, PublicKeyToken=96b446c9e63eae34
// MVID: 55C6A6E3-E2E0-4EF5-90A0-9EEBE61A5F60
// Assembly location: C:\Users\gunes\OneDrive\Masaüstü\SevenSpikes-InstantSearch\SevenSpikes.Core\Nop.Plugin.InstantSearch.Dotless.dll

namespace Nop.Plugin.InstantSearch.Dotless.Loggers
{
  public class NullLogger : Logger
  {
    private static readonly NullLogger instance = new NullLogger(LogLevel.Warn);

    public NullLogger(LogLevel level)
      : base(level)
    {
    }

    protected override void Log(string message)
    {
    }

    public static NullLogger Instance => NullLogger.instance;
  }
}