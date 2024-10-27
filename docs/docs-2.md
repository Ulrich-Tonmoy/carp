# More operators

[Previous](docs-1.md) |
[Next](docs-3.md)

## Completed items

- Generalized parsing using precedences
- Support unary operators, such as `+2` and `-3`
- Support for Boolean literals (`false`, `true`)
- Support for conditions such as `1 == 3 && 2 != 3 || true`
- Internal representation for type checking (`Binder`, and `BoundNode`)

## Interesting aspects

### Generalized precedence parsing

At [first](1.md), I've written recursive descent
parser in such a way that it parses additive and multiplicative expressions
correctly. I did this by parsing `+` and `-` in one method (`ParseTerm`) and
the `*` and `/` operators in another method `ParseFactor`. However, this doesn't
scale very well if you have a dozen operators. In this, I've replaced
this with unified method.

### Bound tree

The first version of the evaluator was walking the syntax tree directly. But the
syntax tree doesn't have any _semantic_ information, for example, it doesn't
know which types an expression will be evaluating to. This makes more
complicated features close to impossible, for instance having operators that
depend on the input types.

To tackle this, I've introduced the concept of a _bound tree_. The bound tree
is created by the Binder by walking the syntax tree and _binding_ the
nodes to symbolic information. The binder represents the semantic analysis of
our compiler and will perform things like looking up variable names in scope,
performing type checks, and enforcing correctness rules.

You can see this in action in Binder.BindBinaryExpression which
binds `BinaryExpressionSyntax` to a BoundBinaryExpression. The
operator is looked up by using the types of the left and right expressions in
BoundBinaryOperator.Bind.
