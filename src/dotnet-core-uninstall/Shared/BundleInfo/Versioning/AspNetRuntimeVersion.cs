﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.DotNet.Tools.Uninstall.Shared.BundleInfo.Versioning
{
    internal class AspNetRuntimeVersion : BundleVersion, IComparable, IComparable<AspNetRuntimeVersion>, IEquatable<AspNetRuntimeVersion>
    {
        public override BundleType Type => BundleType.AspNetRuntime;
        public override BeforePatch BeforePatch => new MajorMinorVersion(Major, Minor);

        public AspNetRuntimeVersion() { }

        public AspNetRuntimeVersion(string value) : base(value) { }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as AspNetRuntimeVersion);
        }

        public int CompareTo(AspNetRuntimeVersion other)
        {
            return other == null ? 1 : SemVer.CompareTo(other.SemVer);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AspNetRuntimeVersion);
        }

        public bool Equals(AspNetRuntimeVersion other)
        {
            return other != null &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }

        public override Bundle ToBundle(BundleArch arch, string uninstallCommand, string displayName)
        {
            return new Bundle<AspNetRuntimeVersion>(this, arch, uninstallCommand, displayName);
        }
    }
}
