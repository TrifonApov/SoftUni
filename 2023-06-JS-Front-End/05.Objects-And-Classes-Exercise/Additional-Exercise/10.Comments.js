function solve (input) {
    // article
    //   - users
    //     - comment1
    //     - comment2

    const articles = [];
    const users = {};

    input.forEach(line => {
        if (line.startsWith('user ')) {
            const user = line.substring(5);
            users[user] = {};
            console.log();
        } else if (line.startsWith('article ')) {
            const article = line.substring(8);
            articles.push(article);
        }
    });
}


solve([
    'user aUser123',
    'someUser posts on someArticle: NoTitle, stupidComment',
    'article Books',
    'article Movies',
    'article Shopping',
    'user someUser',
    'user uSeR4',
    'user lastUser', 
    'uSeR4 posts on Books: I like books, I do really like them',
    'uSeR4 posts on Movies: I also like movies, I really do',
    'someUser posts on Shopping: title, I go shopping every day',
    'someUser posts on Movies: Like, I also like movies very much'
]);

// Comments on Movies
// --- From user someUser: Like - I also like movies very much
// --- From user uSeR4: I also like movies - I really do Comments on Books
// --- From user uSeR4: I like books - I do really like them
// Comments on Shopping
// --- From user someUser: title - I go shopping every day