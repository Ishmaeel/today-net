# Today!

A tiny command line tool to datestamp your files and folders.

Accepts a single argument. The argument can be a file or folder path.

Appends today's date to file names:

```
Today! C:\Work\mynotes.txt 
> mynotes.2021.08.12.txt
```

Prepends today's date to folder names, for easy sorting:

```
Today! C:\Work\reports
> 2021.08.12 reports
```

Tries not to overwrite or mess with existing files or folders.

Comes with no guarantees that it will not overwrite or mess with existing files or folders.
