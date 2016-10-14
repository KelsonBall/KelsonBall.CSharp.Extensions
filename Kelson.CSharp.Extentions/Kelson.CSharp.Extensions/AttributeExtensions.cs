////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;
using System.Reflection;

namespace Kelson.CSharp.Extensions
{
    public static class AttributeExtensions
    {
        public static bool HasAttribute<TAttribute>(this FieldInfo field) where TAttribute : Attribute
        {
            return Attribute.IsDefined(field, typeof(TAttribute));
        }

        public static bool HasAttribute<TAttribute>(this MethodInfo method) where TAttribute : Attribute
        {
            return Attribute.IsDefined(method, typeof(TAttribute));
        }

        public static bool HasAttribute<TAttribute>(this PropertyInfo property) where TAttribute : Attribute
        {
            return Attribute.IsDefined(property, typeof(TAttribute));
        }

        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return Attribute.IsDefined(type, typeof(TAttribute));
        }

        public static bool HasAttribute<TAttribute>(this object obj) where TAttribute : Attribute
        {
            return Attribute.IsDefined(obj.GetType(), typeof(TAttribute));
        }

        public static bool HasAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            return Attribute.IsDefined(assembly, typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this FieldInfo field) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(field, typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this MethodInfo method) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(method, typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo property) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(property, typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(type, typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this object obj) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(TAttribute));
        }

        public static TAttribute GetAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(assembly, typeof(TAttribute));
        }
    }
}