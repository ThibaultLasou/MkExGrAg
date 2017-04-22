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
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController() : this(new Dal())
        {
        }

        public LoginController(IDal dalIoc)
        {
            this.dal = dalIoc;
        }

        // GET: Login
        public ActionResult Index()
        {
            IndividuViewModel uvm = new IndividuViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };

            if (HttpContext.User.Identity.IsAuthenticated)
                uvm.Individu = dal.ObtenirIndividu();

            return View(uvm);
        }

        [HttpPost]
        public ActionResult Index(IndividuViewModel uvm, string returnUrl)
        {
            if (!ModelState.IsValid) //Vérifie la présence du login et du mot de passe
                return View(uvm);

            Individu ind = dal.Authenticate(uvm.Individu.userLogin, uvm.Individu.numCarte);
            if (ind != null) //Authentification réussie
            {
                FormsAuthentication.SetAuthCookie(ind.Id.ToString(), false);
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return Redirect("/");
            }

            //"Login" est le getter dans le viewModel
            ModelState.AddModelError("Login", "Identifiant et/ou numéro de carte invalide(s)");
            return View(uvm);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}