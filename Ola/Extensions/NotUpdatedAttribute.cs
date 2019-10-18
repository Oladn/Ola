﻿using System;

namespace Ola.Extensions
{
    /// <summary>
    /// 忽略更新。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotUpdatedAttribute : Attribute
    {

    }
}