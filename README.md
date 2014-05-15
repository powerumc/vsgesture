What's Markdown ToC
=====================

Markdown ToC is a composition library to render the **Markdown Flavored Syntax** and Create the **ToC(Table of Contents)** automatically.
You're only markdown file, such as readme.md file.

# Method 1. Local Repository

1. You can download a zip file at [this link](https://github.com/powerumc/markdown-toc/archive/master.zip).
2. And unzip a zipfile.
3. You have to modify a README.md file what contents do you want.
4. Upload your repository or git commit and push.

# Method 2. GitHub gh-pages branch.

Github gh-pages branch can host web page on github.com.

## 1. Add remote repository the Markdown-ToC

```
$ git remote add markdown-toc git@github.com:powerumc/markdown-toc.git            # by ssh

$ git remote add markdown-toc https://github.com/powerumc/markdown-toc.git        # by https

```

## 2. Ready in your repository

You should be  new branch is gh-pages without parent branch(--orphan).
And remove all repository files.

```
$ git checkout --orphan gh-pages

$ git rm -rf .

$ git commit -am "remove all file for gh-pages"

$ git pull markdown-toc master:gh-pages

```

## 3. Modify your README.md

All right. Modify your contents in README.md, commit a README.md.

```
$ git commit -am "init commit."
```

If you want to get it what is README.md from another branch.

```
$ git checkout master -- README.md

$ git commit
```


## 4. Push these

```
$ git push origin gh-pages
```

