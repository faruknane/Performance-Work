﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using PerformanceWork;
using PerformanceWork.OptimizedNumerics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;

namespace PerformanceWorkTests
{
    public unsafe class Program
    {
        public static int Size = 10;

        private static void MatrixMultiply()
        {
            //Vectorization.MatrixMultiply(ref a, ref b, ref c);
            MKL.cblas_sgemm(MKL.ORDER.RowMajor, MKL.TRANSPOSE.NoTrans, MKL.TRANSPOSE.NoTrans, a.D1, b.D2, b.D1, 1.0f, a.GetPointer(), b.D1, b.GetPointer(), b.D2, 0.0f, c.GetPointer(), b.D2);
        }

        public static Matrix a, b, c;
        public static bool ArrayEqual<T>(T[] v1, T[] v2)
        {
            if (v1.Length != v2.Length) return false;
            for (int i = 0; i < v1.Length; i++)
                if (!v1[i].Equals(v2[i]))
                    return false;
            return true;
        }
        static unsafe void Main(string[] args)
        {
            a = new Matrix(Size, Size);
            b = new Matrix(Size, Size);
            c = new Matrix(Size, Size);

            for (int i = 0; i < a.D1; i++)
                for (int j = 0; j < a.D2; j++)
                    a[i, j] = i;

            for (int i = 0; i < a.D1; i++)
                for (int j = 0; j < a.D2; j++)
                    b[i, j] = j;

            //for (int i = 0; i < a.D1; i++)
            //    for (int j = 0; j < a.D2; j++)
            //        c[i, j] = i + j;

            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int x = 7;
                MKL.vmsAdd(c.D1 * c.D2, a.GetPointer(), b.GetPointer(), c.GetPointer(), Vectorization.Mode);
                i += x;
                i -= x;
            }

            s.Stop();
            Console.WriteLine($"me -> {s.ElapsedMilliseconds}"); s.Start();
            s.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                Vectorization.ElementWiseAddAVX(a.GetPointer(), b.GetPointer(), c.GetPointer(), c.D1 * c.D2);
            }
            s.Stop();
            Console.WriteLine($"me -> {s.ElapsedMilliseconds}"); s.Start();
        }


    }
}
