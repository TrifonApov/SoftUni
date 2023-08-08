function loadRepos() {
    async function solve(){
        const response = await fetch("https://api.github.com/users/testnakov/repos");
        const repos = await response.json();

        const div = document.getElementById(res);
        div.textContent = JSON.stringify(repos);
        
    
    }
    solve();
}