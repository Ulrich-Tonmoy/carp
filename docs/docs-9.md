# Episode 9

[Previous](docs-8.md) |
[Next](docs-10.md)

## Completed items

Just made the REPL a bit easier to use. This includes the ability to edit multiple lines, have history, and syntax highlighting.

## Interesting aspects

### Two classes

The REPL is split into two classes:

- Repl is a generic REPL editor and deals with the interception of keys and
  rendering.
- CarpRepl contains the Minsk specific portion, specifically evaluating the
  expressions, keeping track of previous compilations, and using the parser to
  decide whether a submission is complete.

I haven't done this to reuse the REPL, but to make it easier to maintain. It's not great if the language specific aspects of the REPL are mixed with the tedious components of key processing and output rendering.

## Document/View

The REPL uses a simple document/view architecture to update the output of the screen whenever the document changes.
