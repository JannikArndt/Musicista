#!/bin/sh

git fetch
if [[ "$(git rev-parse HEAD)" != "$(git rev-parse @{u})" ]]
	then echo "\033[31mCurrent branch is not up-to-date, please pull first!\033[0m"
	exit
fi

echo "\033[0;32mDeploying updates to GitHub...\033[0m"

echo "\033[2m"
# Build the project.
hugooutput="$(hugo)"
echo "$hugooutput"
echo "\033[0m"

if echo "$hugooutput" | grep "ERROR"
  then echo "\033[31mError during build, cancelling deployment. 🙁\033[0m"
  exit
fi

# Add changes to git.
git add -A

# Commit changes.
if [ $# -eq 1 ]
    then msg="$1"
else
    echo "\033[1mCommit message: "
    read "newmsg"
    echo "\033[0m"
    msg="$newmsg"
fi

git commit -m "$msg"

# Push source and build repos.
git push origin master

# Add, Commit and Push `public` subtree to gh-pages branch
cd public/
git add -A
git commit -m "$msg"
git push origin master

echo "New version is deployed 👍"
