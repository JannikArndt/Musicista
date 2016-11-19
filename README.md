# Musicista Hugo Site Branch

This branch keeps the [hugo](http://gohugo.io/)-sources for http://jannikarndt.github.io/Musicista/, which is generated into the `public` folder, which is a git submodule to the `gh-pages` branch.

    git submodule add -b gh-pages git@github.com:JannikArndt/Musicista.git public

To update

1. run `hugo` command
2. `add`, `commit` and `push` changes
3. `cd` into `public` 
4. `add`, `commit` and `push` changes