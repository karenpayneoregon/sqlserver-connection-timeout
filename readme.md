# About

Code sample which sets a timeout on a SqlConnection which constrains opening a connection to a four second time period which is adjustable.

This can assist when there is a failure to connection to a SQL-Server where without a timeout will timeout in 30 or more seconds which can be a lifetime for a user.

:heavy_check_mark: On connection failure the exception is written to a log file for SqlServerAsyncRead project.

:green_circle: SqlServerAsyncRead recommended with connections that may fail.

:red_circle: SqlServerConventional do not use if a connection may fail

# Microsoft TechNet article

https://social.technet.microsoft.com/wiki/contents/articles/54260.sql-server-friezes-when-connecting-c.aspx