﻿using System.IO;
using Perceptash.Computers;
using Perceptash.Transformers;

namespace Perceptash
{
    /// <summary>
    /// Interface used for implementing calculation hash methods.
    /// </summary>
    public interface IImageHasher
    {
        /// <summary>
        /// Implementation of image conversion methods.
        /// </summary>
        IImageTransformer Transformer { get; }

        /// <summary>
        /// Returns hash of the image.
        /// </summary>
        /// <typeparam name="THash">Type of hash value.</typeparam>
        /// <param name="stream">Stream to the image.</param>
        /// <param name="computer">Implementation of hash calculation algorithm.</param>
        THash Calculate<THash>(Stream stream, IImageHashComputer<THash> computer)
            where THash : struct, IImageHashComparable<THash>;
    }
}
