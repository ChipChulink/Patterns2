// Примеры из .NET

// Entity Framework (EF Core)
// Эта библиотека использует динамические прокси-классы для реализации Lazy Loading.
// При доступе к свойствам навигации EF создаёт proxy-объект, который перехватывает обращение к данным и подгружает их из базы только при необходимости.
// Пример:
public class Student
{
   public int Id { get; set; }
   public string Name { get; set; }
   public virtual ICollection<Course> Courses { get; set; }
}
// Если включена Lazy Loading, Courses будет прокси-объектом, который загрузит данные только при обращении.


// WCF (Windows Communication Foundation)
// Клиентские прокси-классы, автоматически создаваемые для связи с удалёнными сервисами.
// Пример: ServiceReferenceClient — это proxy-объект, который обращается к реальному сервису через сеть.


// Castle DynamicProxy / Moq
// Библиотеки для создания runtime-proxy при тестировании.
// Пример:
// {
//     var mock = new Mock<IUserService>();
//     mock.Setup(x => x.GetUser()).Returns(new User());
//     IUserService service = mock.Object;
// }