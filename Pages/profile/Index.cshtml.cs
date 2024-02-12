using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Dto;
using Store.Entities;

namespace dotnetStore.Pages;

public class ProfilePage : PageModel {

    private readonly DataContext _context;

    public List<AppUser>? users;

    public ProfilePage(DataContext context) {
        _context = context;
    }

    public async void OnGet(){
        try
        {
            users = await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void OnPost(){
        // RegisterDto data = (RegisterDto)Request.Form;
    }
}

