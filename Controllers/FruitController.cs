using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitShare.Models;

namespace FruitShare.Controllers
{
    public class FruitController : Controller
    {
        private FruitShareContext _context;
        public FruitController( FruitShareContext context )
        {
            _context = context;
        }


        public IActionResult AddNewFruitPage()
        {
            return View( "AddPage" );
        }


        public IActionResult Dashboard()
        {
            if( HttpContext.Session.GetInt32( "UserId" ) == null )
            {
                return RedirectToAction( "Index", "Home" );
            }
            User RetrievedUser = _context.Users.SingleOrDefault( u => u.UserId == ( int ) HttpContext.Session.GetInt32( "UserId" ));

            List<Fruit> AllFruits = _context.Fruits
                                                    .OrderBy( rev => rev.FruitName )
                                                    .Include( c => c.CreatedBy )
                                                    .Include( w => w.FruitLovers )
                                                    .ThenInclude( g => g.User )
                                                    .ToList();

            ViewBag.LoggedId = HttpContext.Session.GetInt32( "UserId" );

            ViewBag.RetrievedUser = RetrievedUser;

            return View( "Success", AllFruits );
        }


        public IActionResult CreateFruitForm( FruitViewModel model )
        {
            if( ModelState.IsValid )
            {
                User CurrentUser = _context.Users.Include( u => u.Fruits ).SingleOrDefault( u => u.UserId == ( int ) HttpContext.Session.GetInt32( "UserId" ));

                Fruit NewFruit = new Fruit
                {
                    FruitName = model.FruitName,
                    FruitType = model.FruitType,
                    FruitNotes = model.FruitNotes,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedById = CurrentUser.UserId
                };

                _context.Fruits.Add( NewFruit );
                _context.SaveChanges();

                NewFruit = _context.Fruits.SingleOrDefault( a => a.FruitNotes == model.FruitNotes );
                HttpContext.Session.SetInt32( "GameId", NewFruit.FruitId );
                return RedirectToAction( "ShowDetails", new { id = HttpContext.Session.GetInt32( "GameId" )});
            }
            return View( "AddPage" );
        }


        public IActionResult ShowDetails( int id )
        {
            if( HttpContext.Session.GetInt32( "UserId" ) == null )
            {
                return RedirectToAction( "Index", "Home" );
            }

            Fruit ThisFruit = _context.Fruits
                                            .Include( c => c.CreatedBy )
                                            .Include( g => g.FruitLovers )
                                            .ThenInclude( u => u.User )
                                            .SingleOrDefault( w => w.FruitId == id );


            List<FruitLover> ThisParticularFruit = _context.FruitLovers
                                                            // .Include( c => c.CreatedBy )
                                                            // .Include( w => w.FruitLovers )
                                                            // .ThenInclude( g => g.User )
                                                            .Include( g => g.User)
                                                            .Where( w => w.fruits_FruitId == id )
                                                            .ToList();

            ViewBag.ThisParticularFruit = ThisParticularFruit;
            ViewBag.ThisFruit = ThisFruit;

            ViewBag.LoggedId = HttpContext.Session.GetInt32( "UserId" );

            return View( "Detail", ThisParticularFruit );
        }


        public IActionResult DeleteFruitForm( int id )
        {
            Fruit x = _context.Fruits.SingleOrDefault( wed => wed.FruitId == id );
            _context.Fruits.Remove( x );
            _context.SaveChanges();
            return RedirectToAction( "Dashboard" );
        }


        public IActionResult JoinFruitGroup( int id )
        {
            Fruit x = _context.Fruits
                                    .Include( a => a.FruitLovers )
                                    .ThenInclude( a => a.User )
                                    .SingleOrDefault( a => a.FruitId == id );

            FruitLover gg = new FruitLover{ users_UserId = ( int ) HttpContext.Session.GetInt32( "UserId" ), fruits_FruitId = x.FruitId };

            _context.FruitLovers.Add( gg );
            _context.SaveChanges();
            return RedirectToAction( "Dashboard" );
        }


        public IActionResult LeaveFruitGroup( int id )
        {
            FruitLover gg = _context.FruitLovers
                                        .SingleOrDefault( a => a.users_UserId == ( int ) HttpContext.Session.GetInt32( "UserId" ) && a.fruits_FruitId == id );

            _context.FruitLovers.Remove( gg );
            _context.SaveChanges();
            return RedirectToAction( "Dashboard" );
        }




//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public IActionResult MyClaimedFruit(  )
        {
            if( HttpContext.Session.GetInt32( "UserId" ) == null )
            {
                return RedirectToAction( "Success", "Fruit" );
            }
            User RetrievedUser = _context.Users.SingleOrDefault( u => u.UserId == ( int ) HttpContext.Session.GetInt32( "UserId" ));

            // User SharingUser = _context.Fruits
            //                                 .Include( c => c.CreatedById )
            //                                 .Include( f => f.FruitLovers )
            //                                 .ThenInclude( u => u.User)
            //                                 .Where( Fruits.CreatedById == users.UserId )
            //                                 .SingleOrDefault();



            List<FruitLover> FruitImClaiming = _context.FruitLovers
                                                        .Include( c => c.User )
                                                        .Include( a => a.Fruit )
                                                        .ThenInclude( c => c.CreatedBy )
                                                        //.ThenInclude( u => u.User )
                                                        
                                                        .Where( w => w.users_UserId == RetrievedUser.UserId )
                                                        .ToList();

            ViewBag.RetrievedUser = RetrievedUser;

            return View( "UserClaimingPage", FruitImClaiming );
        }







//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        public IActionResult MySharedFruit( )
        {
            if( HttpContext.Session.GetInt32( "UserId" ) == null )
            {
                return RedirectToAction( "Success", "Fruit" );
            }
            User RetrievedUser = _context.Users.SingleOrDefault( u => u.UserId == ( int ) HttpContext.Session.GetInt32( "UserId" ));

            List<Fruit> FruitImSharing = _context.Fruits
                                                        .OrderBy( r => r.FruitName )
                                                        .Include( u => u.CreatedBy )
                                                        .Where( w => w.CreatedById == RetrievedUser.UserId )
                                                        .ToList();

            ViewBag.RetrievedUser = RetrievedUser;

            return View( "UserSharingPage", FruitImSharing );
        }









        public IActionResult FruitDetailsToEdit( int id )
        {
            if( HttpContext.Session.GetInt32( "UserId" ) == null )
            {
                return RedirectToAction( "Index", "Home" );
            }

            Fruit EditableFruit = _context.Fruits
                                                .Include( r => r.CreatedBy )
                                                .SingleOrDefault( w => w.FruitId == id );

            ViewBag.EditableFruit = EditableFruit;

            return View( "EditPage", EditableFruit );
        }


        public IActionResult EditFruitForm( int id, Fruit model )
        {
            Console.WriteLine(id);
            Fruit RetrievedFruit = _context.Fruits.SingleOrDefault( fr => fr.FruitId == id );

            RetrievedFruit.FruitName = model.FruitName;
            RetrievedFruit.FruitType = model.FruitType;
            RetrievedFruit.FruitNotes = model.FruitNotes;

            _context.SaveChanges();

            return RedirectToAction( "Dashboard" );
        }
    }
}