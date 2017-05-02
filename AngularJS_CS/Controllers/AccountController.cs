using AngularJS_CS.Models;
using AngularJS_CS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AngularJS_CS.Controllers
{
    public class AccountController : Controller
    {
        private IDal dal;

        public AccountController() : this(new Dal())
        {
        }

        public AccountController(IDal dalIoc)
        {
            this.dal = dalIoc;
        }

        // GET: Login
        public ActionResult Index()
        {
            //LoginViewModel uvm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };

            //if (HttpContext.User.Identity.IsAuthenticated)
            //    uvm.Individu = dal.ObtenirIndividu();

            return View();
        }

        public ActionResult Index(LoginViewModel model)
        {
            //LoginViewModel uvm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };

            //if (HttpContext.User.Identity.IsAuthenticated)
            //    uvm.Individu = dal.ObtenirIndividu();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) //Vérifie la présence du login et du mot de passe
            {
                return View(model);
            }

            Individu ind = dal.Authenticate(model.UserID, model.Password);

            if (ind != null) //Authentification réussie
            {
                FormsAuthentication.SetAuthCookie(ind.Id.ToString(), false);
                model.Authenticated = true;
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return View("../Home/Index", model);
            }

            //"Login" est le getter dans le viewModel
            ModelState.AddModelError(nameof(Login), "Identifiant et/ou numéro de carte invalide(s)");
            return View(model);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}