﻿// Accord Math Library
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

namespace Accord.Math.Integration
{
    using System;

    /// <summary>
    ///   Common interface for multidimensional integration methods.
    /// </summary>
    ///
    public interface IMultidimensionalIntegration : INumericalIntegration
    {
        /// <summary>
        ///   Gets the number of parameters expected by
        ///   the <see cref="Function"/> to be integrated.
        /// </summary>
        ///
        int NumberOfParameters { get; }

        /// <summary>
        ///   Gets or sets the multidimensional function
        ///   whose integral should be computed.
        /// </summary>
        ///
        Func<double[], double> Function { get; set; }

        /// <summary>
        ///   Gets or sets the range of each input variable
        ///   under which the integral must be computed.
        /// </summary>
        ///
        DoubleRange[] Range { get; }
    }
}