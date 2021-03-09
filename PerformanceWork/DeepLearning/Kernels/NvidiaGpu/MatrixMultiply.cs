﻿using PerformanceWork.NCuda;
using PerformanceWork.OptimizedNumerics;
using PerformanceWork.OptimizedNumerics.Tensors;
using System;
using System.Runtime.CompilerServices;

namespace PerformanceWork.DeepLearning.Kernels.NvidiaGpu
{
    public unsafe static partial class NvidiaGpuKernels
    {
        /// <summary>
        /// Returns the sum of tensors.
        /// </summary>
        /// <param name="tensors">Tensors to be summed</param>
        /// <returns>The sum of tensors</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static Tensor MatrixMultiplyFloat32(Tensor a, Tensor b)
        {
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static void MatrixMultiplyFloat32(Tensor res, Tensor a, Tensor b, float cofmul = 1, float cofadd = 0)
        {

        }

    }
}
