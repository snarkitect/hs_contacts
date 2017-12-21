### Notes:
This still needs a lot of work.
I started with the dotnet angular template and spent the first 45 minutes researching how to set up authorization in a way that made sense. When I realized I had used nearly half of my available time I decided it was more important to get something up and running and come back to auth.  It seems like adding that should be pretty straightforward if I knew the framework and did a little more angular research.

There's a very simple UI to view, add and edit contacts, but I wasn't able to get into the meat of the problem.
I hadn't used .Net in a few years until this week, and I'd never used Angular until last night. I've been using rails and knockout for the last 3 years. The concepts make sense, but I wasn't familiar enough with these particular frameworks to get as far as I'd like.

### The next steps as I see them are to:
1. Expand upon comments as we buildout
2. Add authentication and authorization
3. Add in user management flows (sign in, register, change password, forgotten password etc.)
4. add server side validation
5. add client side validation
6. reorganize front end models a bit to smooth out interactions and avoid repeat code for the Contact interface
7. Add paging and search functionality
8. Figure out bug with hard refresh erroring from angular routes
9. Figure out testing for models and controllers
    * Test to validate users only have access to each controller action for their own data.
    * Tests to ensure models won't save without validation passing
    * Tests for authentication flow
10. Switch database providers to something production ready.
 


