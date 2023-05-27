# Docs 3

[Previous](docs-2.md) |
[Next](docs-4.md)

## Completed items

- Extracted compiler into a separate library
- Exposed span on diagnostics that indicate where the error occurred
- Support for assignments and variables

## Interesting aspects

### Compilation API

Added a type called `Compilation` that holds onto the entire state of the
program. It will eventually expose declared symbols as well and house all
compiler operations, such as emitting code. For now, it only exposes an
`Evaluate` API that will interpret the expression:

```C#
var syntaxTree = SyntaxTree.Parse(line);
var compilation = new Compilation(syntaxTree);
var result = compilation.Evaluate();
Console.WriteLine(result.Value);
```

### Assignments as expressions

One controversial aspect of the C language family is that assignments are
usually treated as expressions, rather than isolated top-level statements. This
allows writing code like this:

```C#
a = b = 5
```

It is tempting to think about assignments as binary operators but they will have
to parse very differently. For instance, consider the parse tree for the
expression `a + b + 5`:

```
    +
   / \
  +   5
 / \
a   b
```

This tree shape isn't desired for assignments. Rather, you'd want:

```
  =
 / \
a   =
   / \
  b   5
```

which means that first `b` is assigned the value `5` and then `a` is assigned
the value `5`. In other words, the `=` is _right associative_.

Furthermore one needs to decide what the left-hand-side of the assignment
expression can be. It usually is just a variable name, but it could also be a
qualified name or an array index. Thus, most compilers will simply represent it
as an expression. However, not all expressions can be assigned to, for example
the literal `5` couldn't. The ones that can be assigned to, are often referred
to as _L-values_ because they can be on the left-hand-side of an assignment.

In our case, we currently only allow variable names, so we just represent it as
single token, rather than as a general expression. This also makes
parsing them very easy as can just peek ahead.
