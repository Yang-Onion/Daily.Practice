using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.IdentityDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Asp.NetCore.IdentityDemo.Services.Impl
{
    public class AppUserManager : UserManager<AppUser>
    {
        private readonly IServiceProvider _serviceProvider;

        public AppUserManager(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators,
            IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services,logger) {
            _serviceProvider = services;
        }

        public override Task<AppUser> FindByIdAsync(string userId) {
            var user = Users.Include(x => x.Roles).FirstOrDefaultAsync(u => u.Id.Equals(userId));
            return user;
        }

        public override Task<AppUser> FindByNameAsync(string normalizedUserName) {
            return Users.Include(x => x.Roles).FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName);
        }

        public bool IsUserNameUsed(string userName) {
            return Users.FirstOrDefault(x => x.UserName == userName) != null;
        }

        public bool IsPhoneNumberUsed(string phoneNumber) {
            return Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber) != null;
        }

        //public async Task AllocateRole(string userId, RoleEnum role) {
        //    var signInManager = _serviceProvider.GetService(typeof(SignInManager)) as SignInManager;

        //    var user = await FindByIdAsync(userId);
        //    await AddToRoleAsync(user, role.GetDescription());
        //    user.ModuleType = user.ModuleType | this.GetModule(role);

        //    var res = await UpdateAsync(user);

        //    if (!res.Succeeded)
        //        throw new DomainException("分配角色失败" + res.Errors.First().Description);
        //}

        //public PagedList<AppUser> FindAllAppUser(AppUserQueryDto appUserQueryDto) {
        //    if (!string.IsNullOrEmpty(appUserQueryDto.UserName)) {
        //        return Users.Where(g => g.UserName.Equals(appUserQueryDto.UserName)).ToPagedList(appUserQueryDto);
        //    }
        //    return Users.ToPagedList(appUserQueryDto);
        //}

        public AppUser FindAppUserByPhone(string phoneNumber) {
            return Users.FirstOrDefault(g => g.PhoneNumber.Equals(phoneNumber));
        }

        public async Task<IdentityResult> AddToRoles(AppUser user, List<IdentityRole> roleName, string roleId) {
            if (roleName.Count > 0) {
                var temp = new List<string>();
                roleName.ForEach(l => {
                    temp.Add(l.NormalizedName);
                });
                var result = await RemoveFromRolesAsync(user, temp);
                if (result.Errors.Any()) {
                    return result;
                }
            }
            user.Roles.Clear();

            if (!string.IsNullOrEmpty(roleId)) {
                foreach (var a in roleId.Split(',')) {
                    user.Roles.Add(new IdentityUserRole<string> { RoleId = a, UserId = user.Id });
                }
            }
            return await UpdateAsync(user);
        }

        //public PlatformModuleTypeEnum GetModule(RoleEnum roleType) {
        //    switch (roleType) {
        //        case RoleEnum.RoadAdmin:
        //        case RoleEnum.RoadBranchAdmin:
        //        case RoleEnum.RoadBranchUser:
        //            return PlatformModuleTypeEnum.Road;

        //        case RoleEnum.AirAdmin:
        //        case RoleEnum.AirBranchAdmin:
        //        case RoleEnum.AirBranchUser:
        //            return PlatformModuleTypeEnum.Air;

        //        case RoleEnum.CHPPAdmin:
        //        case RoleEnum.CHPPUser:
        //            return PlatformModuleTypeEnum.CHPP;

        //        default:
        //            return PlatformModuleTypeEnum.None;
        //    }
        //}
    }
}