# Book.NET

It is a sytem, which controls the operation between reader and library. 

Entities:

<b>Authors</b>
 - Author_id
 - Author_name
 
<b>Books</b>
  - Book_id
  - Book_title
  - Book_page
  - Book_pub
  - Book_shortDec
  - Book_dec
  - Pub_id
  
<b>BooksHaveAuthors</b>
  - Book_id
  - Author_id
  
 <b>BooksInventory</b>
  - Book_id
  - User_id
  
 <b>BooksRequests</b>
  - Book_id
  - User_id
  
 <b>Publishers</b>
  - Pub_id
  - Pub_name
  
 <b>Userss</b> : IdentityUser
  - FullName
