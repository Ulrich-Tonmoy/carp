# Docs 6

[Previous](docs-5.md) |
[Next](docs-7.md)

## Completed items

- Added colorization to REPL
- Added compilation unit
- Added chaining to compilations
- Added statements
- Added variable declaration statements

## Interesting aspects

### Scoping and shadowing

Logically, scopes are a tree and mirror the structure of the code, for example:

```
{
    var x = 10
    {
        var y = x * 2
        {
            var z = x * y
        }
        {
            var result = x + y
        }
    }
}
```

The outermost scope contains `x`. Within that, there is a nested scope that
contains `y`. Within that, there are two more scopes, one containing `z` and one
containing `result`.

Some programming languages, such as C, allow _shadowing_ which means that a
nested scope can declare variables that conflict with names from an outer scope.
This means that within that scope the new name takes precedence, i.e. _shadows_
the name coming from the outer scope. Other languages, such as C#, disallow
that. In C#, only scopes that aren't in a parent-child relationship can have
conflicting names. For instance, it would be valid to name `result` as `z` as
the these two scopes are peers, but it wouldn't be valid to name `z` as `y`
because it would conflict with the `y` coming from the parent scope.

We're currently not very picky and allow shadowing.

We use the BoundScope class to represent scopes during binding. Before binding
nested statements, we create a new scope scoping:

```C#
private BoundStatement BindBlockStatement(BlockStatementSyntax syntax)
{
    var statements = ImmutableArray.CreateBuilder<BoundStatement>();
    _scope = new BoundScope(_scope);

    foreach (var statementSyntax in syntax.Statements)
    {
        var statement = BindStatement(statementSyntax);
        statements.Add(statement);
    }

    _scope = _scope.Parent;

    return new BoundBlockStatement(statements.ToImmutable());
}
```

### Submissions

In a read-eval-print-loop (REPL) environment everything is ad hoc. Thus, it's
often useful to be able to redeclare variables one has declared earlier, with a
different type if necessary. So logically, you can think of the individual
submissions to the REPL as nesting where the previous submission is a parent of
the current submission (which means the first submission is the root).

Given that we allow shadowing we can model this as representing the previous
submissions as parents of the current scope. To do this, we've down a few
things:

1. We allow compilations to be chained. In other words, subsequent
   submissions create a new `Compilation` by calling
   `previousCompilation.ContinueWith(syntaxTree)`.

2. When binding the new tree, we pass in the previous compilation's
   state.

3. The binder then creates a hierarchy of scopes.

## Expression statements

Languages that separate expressions from statements often allow a specific set
of expressions as statements, for example, assignments, and method calls. We
currently allow any expression to be statements, even ones like `12 + 12`. Since
we currently only experience our language through a REPL, this makes sense.

However, when we're starting to process actual files we'll probably disallow
expressions to be used in statements if they have no side effects as they don't
do anything but heat up the CPU. But at that point we probably also want to
add an option to the compilation that indicates whether or not the compilation
is in REPL mode, in which case we'd allow them again.
