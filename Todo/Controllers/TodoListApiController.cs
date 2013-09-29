using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    public class TodoListApiController : ApiController
    {
        private TodoContext db = new TodoContext();

        // GET api/TodoListApi
        public IQueryable<TodoList> GetTodoLists()
        {
            return db.TodoLists;
        }

        // GET api/TodoListApi/5
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult GetTodoList(int id)
        {
            TodoList todolist = db.TodoLists.Find(id);
            if (todolist == null)
            {
                return NotFound();
            }

            return Ok(todolist);
        }

        // PUT api/TodoListApi/5
        public IHttpActionResult PutTodoList(int id, TodoList todolist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todolist.Id)
            {
                return BadRequest();
            }

            db.Entry(todolist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST api/TodoListApi
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult PostTodoList(TodoList todolist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoLists.Add(todolist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = todolist.Id }, todolist);
        }

        // DELETE api/TodoListApi/5
        [ResponseType(typeof(TodoList))]
        public IHttpActionResult DeleteTodoList(int id)
        {
            TodoList todolist = db.TodoLists.Find(id);
            if (todolist == null)
            {
                return NotFound();
            }

            db.TodoLists.Remove(todolist);
            db.SaveChanges();

            return Ok(todolist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool TodoListExists(int id)
        {
            return db.TodoLists.Count(e => e.Id == id) > 0;
        }
    }
}