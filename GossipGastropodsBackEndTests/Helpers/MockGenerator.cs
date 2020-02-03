using Moq;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEndTests.Helpers
{
    static class MockDbSetGenerator<T, L> where T : class where L : IQueryable
    {
        public static Mock<DbSet<T>> Gen(ref L list)
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(list.Provider);
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Expression)
                .Returns(list.Expression);
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.ElementType)
                .Returns(list.ElementType);
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.GetEnumerator())
                .Returns(list.Cast<T>().GetEnumerator());

            return mockSet;
        }
    }
}
