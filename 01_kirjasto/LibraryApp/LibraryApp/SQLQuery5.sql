select FirstName, LastName, ISBN from Loan left join Member on Loan.MemberId = Member.MemberId
left join Book on Loan.BookId = Book.BookId
where Loan.MemberID is not null