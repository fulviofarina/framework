﻿// Accord Machine Learning Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2016
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//
// Copyright (c) 2007-2011 The LIBLINEAR Project.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
//
//   1. Redistributions of source code must retain the above copyright
//   notice, this list of conditions and the following disclaimer.
//
//   2. Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer in the
//   documentation and/or other materials provided with the distribution.
//
//   3. Neither name of copyright holders nor the names of its contributors
//   may be used to endorse or promote products derived from this software
//   without specific prior written permission.
//
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE REGENTS OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

namespace Accord.MachineLearning.VectorMachines.Learning
{
    using System;
    using Accord.Math.Optimization;
    using System.Threading;
    using Accord.Statistics.Kernels;
    using Accord.Math;

    /// <summary>
    ///   L2-regularized L2-loss linear support vector classification (primal).
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   This class implements a L2-regularized L2-loss support vector machine
    ///   learning algorithm that operates in the primal form of the optimization
    ///   problem. This method has been based on liblinear's <c>l2r_l2_svc_fun</c>
    ///   problem specification, optimized using a <see cref="TrustRegionNewtonMethod">
    ///   Trust-region Newton method</see>. This method might be faster than the often
    ///   preferred <see cref="LinearDualCoordinateDescent"/>. </para>
    ///   
    /// <para>
    ///   Liblinear's solver <c>-s 2</c>: <c>L2R_L2LOSS_SVC</c>. A trust region newton
    ///   algorithm for the primal of L2-regularized, L2-loss linear support vector 
    ///   classification.
    /// </para>
    /// </remarks>
    /// 
    /// <seealso cref="SequentialMinimalOptimization"/>
    /// <seealso cref="LinearDualCoordinateDescent"/>
    /// 
    public class LinearNewtonMethod :
        LinearNewtonMethod<SupportVectorMachine, Linear>,
        ILinearSupportVectorMachineLearning
    {
        /// <summary>
        ///   Obsolete.
        /// </summary>
        [Obsolete("Please do not pass parameters in the constructor. Use the default constructor and the Learn method instead.")]
        public LinearNewtonMethod(KernelSupportVectorMachine model, double[][] input, int[] output)
            : base(model, input, output)
        {
        }

        /// <summary>
        ///   Obsolete.
        /// </summary>
        [Obsolete("Please do not pass parameters in the constructor. Use the default constructor and the Learn method instead.")]
        public LinearNewtonMethod(SupportVectorMachine model, double[][] input, int[] output)
            : base(model, input, output)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearNewtonMethod"/> class.
        /// </summary>
        public LinearNewtonMethod()
        {

        }

        /// <summary>
        /// Creates an instance of the model to be learned. Inheritors
        /// of this abstract class must define this method so new models
        /// can be created from the training data.
        /// </summary>
        protected override SupportVectorMachine Create(int inputs, Linear kernel)
        {
            return new SupportVectorMachine(inputs) { Kernel = kernel };
        }
    }

    /// <summary>
    ///   L2-regularized L2-loss linear support vector classification (primal).
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   This class implements a L2-regularized L2-loss support vector machine
    ///   learning algorithm that operates in the primal form of the optimization
    ///   problem. This method has been based on liblinear's <c>l2r_l2_svc_fun</c>
    ///   problem specification, optimized using a <see cref="TrustRegionNewtonMethod">
    ///   Trust-region Newton method</see>. This method might be faster than the often
    ///   preferred <see cref="LinearDualCoordinateDescent"/>. </para>
    ///   
    /// <para>
    ///   Liblinear's solver <c>-s 2</c>: <c>L2R_L2LOSS_SVC</c>. A trust region newton
    ///   algorithm for the primal of L2-regularized, L2-loss linear support vector 
    ///   classification.
    /// </para>
    /// </remarks>
    /// 
    /// <seealso cref="SequentialMinimalOptimization"/>
    /// <seealso cref="LinearDualCoordinateDescent"/>
    /// 
    public abstract class LinearNewtonMethod<TModel, TKernel> :
        BaseSupportVectorClassification<TModel, TKernel, double[]>
        where TKernel : struct, ILinear<double[]>
        where TModel : SupportVectorMachine<TKernel, double[]>
    {
        TrustRegionNewtonMethod tron;

        double[] z;
        int[] I;
        int sizeI;

        double[] g;
        double[] h;
        double[] wa;

        int biasIndex;

        double tolerance = 0.1;
        int maxIterations = 1000;


        /// <summary>
        ///   Constructs a new Newton method algorithm for L2-regularized
        ///   Support Vector Classification problems in the primal form (-s 2).
        /// </summary>
        /// 
        public LinearNewtonMethod()
        {

        }

        /// <summary>
        ///   Convergence tolerance. Default value is 0.1.
        /// </summary>
        /// 
        /// <remarks>
        ///   The criterion for completing the model training process. The default is 0.1.
        /// </remarks>
        /// 
        public double Tolerance
        {
            get { return this.tolerance; }
            set { this.tolerance = value; }
        }

        /// <summary>
        ///   Gets or sets the maximum number of iterations that should
        ///    be performed until the algorithm stops. Default is 1000.
        /// </summary>
        /// 
        public int MaximumIterations
        {
            get { return this.maxIterations; }
            set { this.maxIterations = value; }
        }



        private double objective(double[] w)
        {
            int[] y = Outputs;

            Xv(Inputs, biasIndex, w, z);

            double f = 0;
            for (int i = 0; i < w.Length; i++)
                f += w[i] * w[i];
            f /= 2.0;

            for (int i = 0; i < y.Length; i++)
            {
                z[i] = y[i] * z[i];
                double d = 1 - z[i];
                if (d > 0)
                    f += C[i] * d * d;
            }

            return f;
        }

        private double[] gradient(double[] w)
        {
            int[] y = Outputs;

            sizeI = 0;
            for (int i = 0; i < y.Length; i++)
            {
                if (z[i] < 1)
                {
                    z[sizeI] = C[i] * y[i] * (z[i] - 1);
                    I[sizeI] = i;
                    sizeI++;
                }
            }

            subXTv(Inputs, biasIndex, I, sizeI, z, g);

            for (int i = 0; i < w.Length; i++)
                g[i] = w[i] + 2 * g[i];

            return g;
        }

        private double[] hessian(double[] s)
        {
            subXv(Inputs, biasIndex, I, sizeI, s, wa);
            for (int i = 0; i < sizeI; i++)
                wa[i] = C[I[i]] * wa[i];

            subXTv(Inputs, biasIndex, I, sizeI, wa, h);
            for (int i = 0; i < s.Length; i++)
                h[i] = s[i] + 2 * h[i];

            return h;
        }

        internal static void Xv(double[][] x, int biasIndex, double[] v, double[] Xv)
        {
            for (int i = 0; i < x.Length; i++)
            {
                double[] s = x[i];

                Accord.Diagnostics.Debug.Assert(s.Length == v.Length - 1);

                double sum = v[biasIndex];
                for (int j = 0; j < s.Length; j++)
                    sum += v[j] * s[j];
                Xv[i] = sum;
            }
        }

        internal static void subXv(double[][] x, int biasIndex, int[] I, int sizeI, double[] v, double[] Xv)
        {
            for (int i = 0; i < sizeI; i++)
            {
                double[] s = x[I[i]];

                Accord.Diagnostics.Debug.Assert(s.Length == v.Length - 1);

                double sum = v[biasIndex];
                for (int j = 0; j < s.Length; j++)
                    sum += v[j] * s[j];
                Xv[i] = sum;
            }
        }

        internal static void subXTv(double[][] x, int biasIndex, int[] I, int sizeI, double[] v, double[] XTv)
        {
            for (int i = 0; i < XTv.Length; i++)
                XTv[i] = 0;

            for (int i = 0; i < sizeI; i++)
            {
                double[] s = x[I[i]];

                Accord.Diagnostics.Debug.Assert(s.Length == XTv.Length - 1);

                for (int j = 0; j < s.Length; j++)
                    XTv[j] += v[i] * s[j];

                XTv[biasIndex] += v[i];
            }
        }


        /// <summary>
        ///   Runs the learning algorithm.
        /// </summary>
        /// 
        protected override void InnerRun()
        {
            int samples = Inputs.Length;
            int parameters = Inputs[0].Length + 1;

            this.z = new double[samples];
            this.I = new int[samples];
            this.wa = new double[samples];

            this.g = new double[parameters];
            this.h = new double[parameters];
            this.biasIndex = parameters - 1;

            tron = new TrustRegionNewtonMethod(parameters)
            {
                Function = objective,
                Gradient = gradient,
                Hessian = hessian,
                MaxIterations = maxIterations,
                Tolerance = tolerance,
                Token = Token
            };

            for (int i = 0; i < tron.Solution.Length; i++)
                tron.Solution[i] = 0;

            tron.Minimize();

            double[] w = tron.Solution;

            Model.SupportVectors = new[] { w.First(Model.NumberOfInputs) };
            Model.Weights = new[] { 1.0 };
            Model.Threshold = w[biasIndex];
        }

        /// <summary>
        ///   Obsolete.
        /// </summary>
        [Obsolete]
        protected LinearNewtonMethod(ISupportVectorMachine<double[]> model, double[][] input, int[] output)
            : base(model, input, output)
        {
        }

        /// <summary>
        ///   Obsolete.
        /// </summary>
        protected LinearNewtonMethod(TModel model, double[][] input, int[] output)
            : base(model, input, output)
        {
        }
    }
}
