using ExtremePC.Courses.Definition.DataInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Dal.Context
{
    // could be migrated to common library, in case of multiple databases...
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions dbOptions)
            : base(dbOptions)
        {

        }

        public BaseDbContext(DbContextOptions<BaseDbContext> dbOptions)
            : base(dbOptions)
        {

        }

        protected virtual void ApplyChangeTrackingInfo()
        {
            var entityEntries = ChangeTracker.Entries().Where(x => x.Entity is IChangeTrackedEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.UtcNow;
            foreach (var entityEntry in entityEntries)
            {
                var changeTrackedEntity = (IChangeTrackedEntity)entityEntry.Entity;
                if (entityEntry.State == EntityState.Added)
                    changeTrackedEntity.CreatedDateTimeUtc = now;
                changeTrackedEntity.ChangedDateTimeUtc = now;
                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("CreatedDateTimeUtc").IsModified = false;
                }
            }
        }

        protected virtual void Validate()
        {
            var entities = from entry in ChangeTracker.Entries()
                           where entry.State == EntityState.Modified || entry.State == EntityState.Added
                           select entry.Entity;

            var validationResults = new List<ValidationResult>();

            var exceptionList = new List<string>();

            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
                {
                    var message = validationResults.Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage))
                                        .Aggregate(string.Empty, (current, result) => current + ("\r\n\tError: \r\n" + $"\t\tFieldName: {result.MemberNames} {result.ErrorMessage}\r\n"));

                    exceptionList.Add(message);
                }
            }

            if (exceptionList.Count > 0)
                throw new InvalidOperationException("Cannot save changes because validation failed:  " + exceptionList.Aggregate(string.Empty, (current, result) => current + result));
        }

        public override int SaveChanges()
        {
            ApplyChangeTrackingInfo();
            Validate();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyChangeTrackingInfo();
            Validate();
            return await base.SaveChangesAsync();
        }
    }
}
