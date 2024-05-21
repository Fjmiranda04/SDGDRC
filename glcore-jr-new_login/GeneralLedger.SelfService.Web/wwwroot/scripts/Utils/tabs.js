function initializeTabs(tabSelector, contentSelector) {
    let subMenuTabs = document.querySelectorAll(tabSelector);
    let subMenuTabsContents = document.querySelectorAll(contentSelector);

    subMenuTabs.forEach((tab, index) => {
        tab.addEventListener('click', () => {
            subMenuTabsContents.forEach(content => {
                content.classList.remove('active');
            });
            subMenuTabs.forEach(tab => {
                tab.classList.remove('active');
            });
            subMenuTabsContents[index].classList.add('active');
            subMenuTabs[index].classList.add('active');
        })
    });
}