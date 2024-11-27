/*Есть многоуровневое дерево
 Написать метод, который вернет дочерний узел с Id равным переданному параметру */

var tree = new Node() { ID = "Корень" };
tree.Children.Add(new Node() { ID = "XXX" });
tree.Children[0].Children.Add(new Node() { ID = "YYY" });

Node a = tree.GetNodeByID("YYY");


if (a != null)
{
    Console.WriteLine(a.ID);
}
else
{
    Console.WriteLine("узел не найден");
}
 
public class Node // Класс узла дерева
{
    public List<Node> Children { get; } = new(); // Инициализация списка сразу
    public string ID { get; set; } = string.Empty; // Установка значения по умолчанию

    // Поиск узла по ID
    public Node? GetNodeByID(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            return null; // Обработка некорректного входного параметра

        // Если текущий узел соответствует ID, возвращаем его
        if (ID == id)
            return this;

        // Рекурсивный поиск в потомках
        foreach (var child in Children)
        {
            var result = child.GetNodeByID(id);
            if (result != null)
                return result;
        }

        return null; // Если узел не найден
    }
}