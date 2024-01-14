using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Day12.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Day12.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            // Delete the authentication cookie
            Response.Cookies.Delete("CfDJ8Gq_52Lf-ZhMsoUjFvHGiNI7VLaCMevhdO-riMFNPliCxWoUl-vQWrIN3F_q2edeMsTQzys-9EzLwEtY_NbZ5L1CE--r31UoQUQZG6-Ddv2AD-TEqWjmCyDRCloqGTMDveKHq9SP1yw6swVAjxv2Na6cCtZkKGlhuvq59Wyg-KoJeRStq1l4o4X-sl947CU1wgPTDY32wJjH62_B5fcC4eeY8Li5jHMVWNTbb38twNkV0K3TXJCsrO-LYlrg8vTDr-Pjd_mwpKl0YJ-0jY8nV_WIbYhgQmLKyERfX5RT14pn1y87cuWkBtOsdrdPEeLQMrMvjWNjAHPIR1MC_0wB3qcWCDzSPG_2Gjc0Rm3htrwE1wQBv3BDRVC7GddIHzOQOppXiNE-UYLGjXC22bIY9DcyTDlJKdZB8QfeFmihLV2euP5P7clo7AlNw3UbaJg6-EsaMsQDB7DI2a3d-pfSq4FAqvg8-lGaZtarFk1vzLfKpD-8fVQ4Z_UoBtwHAsOaM66J0bME8wWvYbO8uAC077P9L9k7smTBeaIpXwohOnMR9Q85TvLfuucltEI5sNujNlDwc25d12PTxHvsiDRCykOwtLfCmQ99fcQxhCO9cSIIq1ZM0B5WKeUVHhLAx16mEyzovisV3G17ZF0cMDMN6-oRdx_S67OU4sZu9nPm8tQjEiISsABOJKUz7-ClYwcZDRTgB_7pWUf4lPVnsZPVei1DVKZP9a5hkhOsK_eoizTVhjKx-PkVTDZI10xjTl7XhEYXNgf_dbWQnXLiu-_aoofdi249Pyx4tt4eWaWi82kJd_iovSeHFUAqpKovgPLXL-BvZTJE9xc8DtQva_pDJD8");

            // Sign the user out
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}



/*// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Day12.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Day12.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
*/