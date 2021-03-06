﻿using AngularJS_CS.Models;
using AngularJS_CS.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AngularJS_CS.Controllers
{
    /// <summary>
    /// Contrôleur du compte
    /// </summary>
    public class AccountController : Controller
    {
        private IDal dal;

		/// <summary>
		/// Constructeur par défaut
		/// </summary>
        public AccountController() : this(new Dal())
        {
        }

		/// <summary>
		/// Constructeur de copie
		/// </summary>
		/// <param name="dalIoc"></param>
        public AccountController(IDal dalIoc)
        {
            this.dal = dalIoc;
        }

        //// GET: Login
        //public ActionResult Index()
        //{
        //    LoginViewModel uvm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };

        //    //if (HttpContext.User.Identity.IsAuthenticated)
        //    //    uvm.Individu = dal.ObtenirIndividu();

        //    return View();
        //}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="model">model</param>
			/// <param name="returnUrl">nom de l'url</param>
			/// <returns></returns>
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            //LoginViewModel uvm = new LoginViewModel { Authenticated = HttpContext.User.Identity.IsAuthenticated };

            //if (HttpContext.User.Identity.IsAuthenticated)
            //    uvm.Individu = dal.ObtenirIndividu();

            return View(model);
        }

        /// <summary>
        /// Tente d'identifier un utilisateur.
        /// </summary>
        /// <param name="model">Modèle de données pour l'identification</param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) //Vérifie la présence du login et du mot de passe
            {
                return RedirectToAction("Index", "Account");
            }

            Individu ind = dal.Authenticate(model.UserID, model.Password);

            if (ind != null) //Authentification réussie
            {
                FormsAuthentication.SetAuthCookie(ind.Id.ToString(), false);
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            //"Login" est le getter dans le viewModel
            ModelState.AddModelError(nameof(Login), "Identifiant et/ou numéro de carte invalide(s)");
            return RedirectToAction("Index", "Account", model);
        }

        /// <summary>
        /// Déconnecte un utilisateur.
        /// </summary>
        /// <returns></returns>
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}