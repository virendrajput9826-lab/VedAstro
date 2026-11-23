using System;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute { }

    public class AssertFailedException : Exception
    {
        public AssertFailedException(string message) : base(message) { }
    }

    public static class Assert
    {
        public static void AreEqual(object? expected, object? actual, string? message = null)
        {
            if (!Equals(expected, actual))
            {
                throw new AssertFailedException(message ?? $"Assert.AreEqual failed. Expected: <{expected}>. Actual: <{actual}>.");
            }
        }

        public static void AreEqual<T>(T expected, T actual, string? message = null)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                throw new AssertFailedException(message ?? $"Assert.AreEqual failed. Expected: <{expected}>. Actual: <{actual}>.");
            }
        }

        public static void AreSame(object? expected, object? actual, string? message = null)
        {
            if (!ReferenceEquals(expected, actual))
            {
                throw new AssertFailedException(message ?? $"Assert.AreSame failed. Expected: <{expected}>. Actual: <{actual}>.");
            }
        }

        public static void IsTrue(bool condition, string? message = null)
        {
            if (!condition)
            {
                throw new AssertFailedException(message ?? "Assert.IsTrue failed.");
            }
        }

        public static void Fail(string? message = null)
        {
            throw new AssertFailedException(message ?? "Assert.Fail failed.");
        }
    }

    public static class CollectionAssert
    {
        public static void AreEqual(System.Collections.ICollection? expected, System.Collections.ICollection? actual)
        {
            if (expected == null && actual == null) return;
            if (expected == null || actual == null)
                throw new AssertFailedException("CollectionAssert.AreEqual failed. One collection is null.");

            if (expected.Count != actual.Count)
                throw new AssertFailedException($"CollectionAssert.AreEqual failed. Expected count: {expected.Count}. Actual count: {actual.Count}.");

            var enumExp = expected.GetEnumerator();
            var enumAct = actual.GetEnumerator();
            while (enumExp.MoveNext() && enumAct.MoveNext())
            {
                if (!Equals(enumExp.Current, enumAct.Current))
                    throw new AssertFailedException($"CollectionAssert.AreEqual failed. Expected element: <{enumExp.Current}>. Actual element: <{enumAct.Current}>.");
            }
        }
    }
}
