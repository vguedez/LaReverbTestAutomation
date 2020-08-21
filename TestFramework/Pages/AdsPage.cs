using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace TestFramework.Pages
{
    public class AdsPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/post/select']")]
        private IWebElement PublishNewAdButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_promo_post_type_1")]
        private IWebElement PromoConcertRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_promo_post_type_2")]
        private IWebElement PromoAlbumRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_promo_post_type_3")]
        private IWebElement PromoEventRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_post_type_1")]
        private IWebElement SearchBandOrProjectRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_post_type_4")]
        private IWebElement SearchServiceRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_sales_post_type_1")]
        private IWebElement EquipmentSalesRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "id_sales_post_type_2")]
        private IWebElement EquipmentBuyRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement CreateNewAdButton { get; set; }

        [FindsBy(How = How.Id, Using = "Post_title")]
        private IWebElement PostTitle { get; set; }
        
        [FindsBy(How = How.Id, Using = "Post_content")]
        private IWebElement PostContent { get; set; }

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement PostSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "PostProfile_is_singer")]
        private IWebElement ProfileIsSingerCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "PostProfile_is_backup_singer")]
        private IWebElement ProfileIsBackupSingerCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()[contains(.,'El anuncio ha sido publicado exitosamente') or contains(.,'El anuncio ha sido guardado exitosamente')]]")]
        private IWebElement AdPostSuccessMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href[contains(.,'/post/band/id_post/')]]")]
        private IList<IWebElement> PostedAdsLinks { get; set; }

        [FindsBy(How = How.Name, Using = "posts[]")]
        private IList<IWebElement> AdsListCheckboxes { get; set; }

        [FindsBy(How = How.Id, Using = "deletePosts")]
        private IWebElement DeleteSelectedAdsButton { get; set; }

        [FindsBy(How = How.Id, Using = "acknowledge")]
        private IWebElement ConfirmDeleteAdButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()[contains(.,'Los anuncios seleccionados han sido eliminados exitosamente')]]")]
        private IWebElement AdDeleteSuccessMessage { get; set; }

        public void GoToMainAdsMenu()
        {
            PublishNewAdButton.Click();
        }

        public void SelectNewSearchBandAd()
        {
            SearchBandOrProjectRadioButton.Click();
        }

        public void ClickOnFirstAdLink()
        {
            PostedAdsLinks[0].Click();
        }

        public void CreateNewAd()
        {
            CreateNewAdButton.Click();
        }

        public void SelectFirstAd()
        {
            AdsListCheckboxes[0].Click();
        }

        public void DeleteSelectedAd()
        {
            DeleteSelectedAdsButton.Click();
        }

        public void ConfirmDeleteSelectedAds()
        {
            Browser.WaitForElements(new List<IWebElement>() { ConfirmDeleteAdButton });
            ConfirmDeleteAdButton.Click();
        }

        public void MarkProfileAsSinger()
        {
            if (!ProfileIsSingerCheckbox.Selected)
            {
                ProfileIsSingerCheckbox.Click();
            }
        }

        public void MarkProfileAsBackupSinger()
        {
            if (!ProfileIsBackupSingerCheckbox.Selected)
            {
                ProfileIsBackupSingerCheckbox.Click();
            }
        }

        public void ClickOnAdLink(string title)
        {
            var AdLink = Browser.Driver.FindElement(By.XPath("//a[text()[contains(.,'" + title + "')]]"));
            AdLink.Click();
        }

        public void SetPostTitleText(string text)
        {
            PostTitle.Clear();
            PostTitle.SendKeys(text);
        }

        public void SetPostContentText(string text)
        {
            PostContent.Clear();
            PostContent.SendKeys(text);
        }

        public string GetPostTitleText()
        {
            return PostTitle.GetAttribute("value");
        }

        public string GetPostContentText()
        {
            return PostContent.GetAttribute("value");
        }

        public void PostAdForm()
        {
            PostSaveButton.Click();
        }

        public bool PromoConcertRadioButtonIsPresent()
        {
            return PromoConcertRadioButton.Displayed;
        }

        public bool PromoAlbumRadioButtonIsPresent()
        {
            return PromoAlbumRadioButton.Displayed;
        }

        public bool PromoEventRadioButtonIsPresent()
        {
            return PromoEventRadioButton.Displayed;
        }

        public bool SearchBandOrProjectRadioButtonIsPresent()
        {
            return SearchBandOrProjectRadioButton.Displayed;
        }

        public bool SearchServiceRadioButtonIsPresent()
        {
            return SearchServiceRadioButton.Displayed;
        }

        public bool EquipmentSalesRadioButtonIsPresent()
        {
            return EquipmentSalesRadioButton.Displayed;
        }

        public bool EquipmentBuyRadioButtonIsPresent()
        {
            return EquipmentBuyRadioButton.Displayed;
        }

        public bool AdIsSaved()
        {
            return AdPostSuccessMessage.Displayed;
        }

        public bool AdIsDeleted()
        {
            return AdDeleteSuccessMessage.Displayed;
        }
    }
}
