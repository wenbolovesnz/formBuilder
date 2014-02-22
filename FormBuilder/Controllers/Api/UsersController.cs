using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormBuilder.Business.Entities;
using FormBuilder.Business.Entities.Enums;
using FormBuilder.Data.Contracts;
using FormBuilder.Models;
using WebMatrix.WebData;

namespace FormBuilder.Controllers.Api
{
    public class UsersController : ApiController
    {
        private IApplicationUnit _applicationUnit;
        private ModelFactory _modelFactory;

        public UsersController(IApplicationUnit applicationUnit)
        {
            _applicationUnit = applicationUnit;
            _modelFactory = new ModelFactory();
        }

        public string Get()
        {
            return "sdfdsfd";
        }

        // POST api/users
        [Authorize(Roles = "Admin")]
        public UserModel Post([FromBody]CreateUserViewModel model)
        {
            User currentUser = _applicationUnit.UserRepository.GetByID(WebSecurity.CurrentUserId);
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    User newUser = _applicationUnit.UserRepository.Get(m => m.UserName == model.UserName).First();
                    newUser.ForceChangePassword = true;
                    newUser.UserType = currentUser.UserType;
                    newUser.Organization = currentUser.Organization;
                    newUser.Roles.Add(_applicationUnit.RoleRepository.GetByID(model.RoleId));
                    return new UserModel {Id = newUser.Id, UserName = newUser.UserName, Organization = null};
        }
    }
}
