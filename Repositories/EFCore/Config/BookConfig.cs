using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Book 1", Price = 75 },
                new Book { Id = 2, Title = "Book 2", Price = 50 },
                new Book { Id = 3, Title = "Book 3", Price = 100 }
                );


        }
    }
}