

namespace PageObjectsExample
{
    internal class ExampleNote
    {
        public ExampleNote()
        {
            Title = Faker.Lorem.Sentence();
            Content = Faker.Lorem.Paragraph();
        }


        public string Title { get; private set; }

        public string Content { get; private set; }
    }
}