using Microsoft.EntityFrameworkCore;
using Patika.Entity.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patika.DataContext
{
    public class WebContext: DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            try
            {
                SetDefaultValues();
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorMessages = string.Join("; ", ex.ToString());
                throw new Exception(errorMessages);
            }
        }

        //public override Task<int> SaveChangesAsync()
        //{
        //    try
        //    {
        //        SetDefaultValues();
        //        return base.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
        //        throw new DbEntityValidationException(errorMessages);
        //    }
        //}
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetDefaultValues();
            //cancellationToken.ThrowIfCancellationRequested();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public int GetCurrentUserId()
        {
            //SessionHelper sessionHelper = new SessionHelper();
            //var currentUserSession = sessionHelper.GetUserViewModel();
            //if (currentUserSession != null)
            //{
            //    var user = currentUserSession as UserViewModel;
            //    return user.CmsUserId;
            //}
            return 1;

        }

        private void SetDefaultValues()
        {
            var currentUserId = GetCurrentUserId();

            var entities = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if (((EntityBase)entity.Entity).CreatedAt == DateTime.MinValue)
                        ((EntityBase)entity.Entity).CreatedAt = DateTime.UtcNow;

                    if (((EntityBase)entity.Entity).CreatedById < 1 && currentUserId > 0)
                        ((EntityBase)entity.Entity).CreatedById = currentUserId;
                }
                else
                {
                    if (!((EntityBase)entity.Entity).UpdatedAt.HasValue)
                        ((EntityBase)entity.Entity).UpdatedAt = DateTime.UtcNow;

                    if (!((EntityBase)entity.Entity).UpdatedById.HasValue && currentUserId > 0)
                        ((EntityBase)entity.Entity).UpdatedById = currentUserId;
                }
            }
        }
    }
}
