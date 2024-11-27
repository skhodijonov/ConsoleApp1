/*Есть многоуровневое дерево
 Написать метод, который вернет дочерний узел с Id равным переданному параметру */

var tree = new Node() { ID = "Корень" };
tree.Children.Add(new Node() { ID = "XXX" });
tree.Children[0].Children.Add(new Node() { ID = "YYY" });

Node a = tree.GetNodeByID("YYY3");


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

        return FindNode(this, id);
    }

    private static Node? FindNode(Node node, string id)
    {
        // Если узел найден, возвращаем его
        if (node.ID == id)
            return node;

        // Рекурсивный поиск в потомках
        foreach (var child in node.Children)
        {
            var result = FindNode(child, id);
            if (result != null)
                return result;
        }

        return null; // Если узел не найден
    }
}