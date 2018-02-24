import { WebCompanionPage } from './app.po';

describe('web-companion App', function() {
  let page: WebCompanionPage;

  beforeEach(() => {
    page = new WebCompanionPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
