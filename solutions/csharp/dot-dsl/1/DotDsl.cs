using System.Collections;

public record Attr(string Key, string Value);

public abstract class Element : IEnumerable<Attr>
{
    private readonly List<Attr> _attrs = [];
    public IEnumerable<Attr> Attrs => _attrs;

    public void Add(string key, string value) => _attrs.Add(new Attr(key, value));
    public IEnumerator<Attr> GetEnumerator() => Attrs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Node(string name) : Element
{
    private string Name { get; } = name;

    public override bool Equals(object? obj) => obj is Node node && node.Name == Name;
    public override int GetHashCode() => HashCode.Combine(Name);
}

public class Edge(string node1, string node2) : Element
{
    private string Node1 { get; } = node1;
    private string Node2 { get; } = node2;

    public override bool Equals(object? obj) =>
        obj is Edge edge && edge.Node1 == Node1 && edge.Node2 == Node2;

    public override int GetHashCode() => HashCode.Combine(Node1, Node2);
}

public class Graph : Element
{
    private readonly List<Node> _nodes = [];
    private readonly List<Edge> _edges = [];
    public IEnumerable<Node> Nodes => _nodes;
    public IEnumerable<Edge> Edges => _edges;

    public void Add(Node node) => _nodes.Add(node);
    public void Add(Edge edge) => _edges.Add(edge);
}
