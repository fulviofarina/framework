﻿// Accord Statistics Library
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

namespace Accord.MachineLearning
{
    /// <summary>
    ///   Common interface for generative observation sequence taggers. A sequence
    ///   tagger can predict the class label of each individual observation in a
    ///   input sequence vector.
    /// </summary>
    ///
    /// <typeparam name="TInput">The data type for the input data. Default is double[].</typeparam>
    ///
    public interface ILikelihoodTagger<TInput> :
        ITransform<TInput[], double>,
        IScoreTagger<TInput>
    {
        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double Probability(TInput[] sequence);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double Probability(TInput[] sequence, ref int[] decision);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] Probability(TInput[][] sequences);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] Probability(TInput[][] sequences, double[] result);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] Probability(TInput[][] sequences, ref int[][] decision);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] Probability(TInput[][] sequences, ref int[][] decision, double[] result);

        /// <summary>
        ///   Predicts a the probability that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double LogLikelihood(TInput[] sequence);

        /// <summary>
        ///   Predicts a the log-likelihood that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double LogLikelihood(TInput[] sequence, ref int[] decision);

        /// <summary>
        ///   Predicts a the log-likelihood that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] LogLikelihood(TInput[][] sequences);

        /// <summary>
        ///   Predicts a the log-likelihood that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] LogLikelihood(TInput[][] sequences, double[] result);

        /// <summary>
        ///   Predicts a the log-likelihood that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] LogLikelihood(TInput[][] sequences, ref int[][] decision);

        /// <summary>
        ///   Predicts a the log-likelihood that the sequence vector
        ///   has been generated by this log-likelihood tagger.
        /// </summary>
        ///
        double[] LogLikelihood(TInput[][] sequences, ref int[][] decision, double[] result);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] Probabilities(TInput[] sequence);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] Probabilities(TInput[] sequence, double[][] result);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] Probabilities(TInput[] sequence, ref int[] decision);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] Probabilities(TInput[] sequence, ref int[] decision, double[][] result);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] LogLikelihoods(TInput[] sequence);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] LogLikelihoods(TInput[] sequence, double[][] result);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] LogLikelihoods(TInput[] sequence, ref int[] decision);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][] LogLikelihoods(TInput[] sequence, ref int[] decision, double[][] result);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] Probabilities(TInput[][] sequences);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] Probabilities(TInput[][] sequences, double[][][] result);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] Probabilities(TInput[][] sequences, ref int[][] decision);

        /// <summary>
        ///   Predicts a the probabilities for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] Probabilities(TInput[][] sequences, ref int[][] decision, double[][][] result);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] LogLikelihoods(TInput[][] sequences);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] LogLikelihoods(TInput[][] sequences, double[][][] result);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] LogLikelihoods(TInput[][] sequences, ref int[][] decision);

        /// <summary>
        ///   Predicts a the log-likelihood for each of the observations in
        ///   the sequence vector assuming each of the possible states in the
        ///   tagger model.
        /// </summary>
        ///
        double[][][] LogLikelihoods(TInput[][] sequences, ref int[][] decision, double[][][] result);
    }
}