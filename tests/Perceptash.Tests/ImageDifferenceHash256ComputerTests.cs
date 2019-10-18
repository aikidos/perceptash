﻿using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Perceptash.Computers;
using Perceptash.Transformers;
using Xunit;

namespace Perceptash.Tests
{
    public sealed class ImageDifferenceHash256ComputerTests
    {
        [Fact]
        public async Task Compute()
        {
            // Arrange
            IImageHashComputer<ImageDifferenceHash256> computer = new ImageDifferenceHash256Computer();

            var transformer = new Mock<IImageTransformer>();
            transformer.Setup(impl => impl.ConvertToGreyscaleAndResizeAsync(It.IsAny<Stream>(), 17, 16, CancellationToken.None))
                .ReturnsAsync(() => Enumerable.Range(1, 272).Reverse().Select(value => (byte) value).ToArray());

            // Act
            ImageDifferenceHash256 hash = await computer.ComputeAsync(Stream.Null, transformer.Object);
            
            ulong[] values = hash
                .GetInternalValuesSpan()
                .ToArray();

            // Assert
            Assert.Equal(Enumerable.Repeat(18446744073709551615UL, 4), values);
        }
    }
}
