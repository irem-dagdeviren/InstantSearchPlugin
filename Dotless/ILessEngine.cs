﻿// Decompiled with JetBrains decompiler
// Type:
//
// .ILessEngine
// Assembly: Nop.Plugin.InstantSearch.Dotless, Version=1.6.7.0, Culture=neutral, PublicKeyToken=96b446c9e63eae34
// MVID: 55C6A6E3-E2E0-4EF5-90A0-9EEBE61A5F60
// Assembly location: C:\Users\gunes\OneDrive\Masaüstü\SevenSpikes-InstantSearch\SevenSpikes.Core\Nop.Plugin.InstantSearch.Dotless.dll

using System.Collections.Generic;

namespace Nop.Plugin.InstantSearch.Dotless
{
  public interface ILessEngine
  {
    string TransformToCss(string source, string fileName);

    void ResetImports();

    IEnumerable<string> GetImports();

    bool LastTransformationSuccessful { get; }

    string CurrentDirectory { get; set; }
  }
}