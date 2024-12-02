// <copyright file="BusinessTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;

    /// <summary>
    /// BusinessTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BusinessTypeEnum
    {
        /// <summary>
        /// Accounting.
        /// </summary>
        [EnumMember(Value = "accounting")]
        Accounting,

        /// <summary>
        /// Acupuncture.
        /// </summary>
        [EnumMember(Value = "acupuncture")]
        Acupuncture,

        /// <summary>
        /// Airlines.
        /// </summary>
        [EnumMember(Value = "airlines")]
        Airlines,

        /// <summary>
        /// AlternativeMedicine.
        /// </summary>
        [EnumMember(Value = "alternative_medicine")]
        AlternativeMedicine,

        /// <summary>
        /// ArtPhotoAndFilm.
        /// </summary>
        [EnumMember(Value = "art_photo_and_film")]
        ArtPhotoAndFilm,

        /// <summary>
        /// AutomobileAssociation.
        /// </summary>
        [EnumMember(Value = "automobile_association")]
        AutomobileAssociation,

        /// <summary>
        /// AutomotiveServices.
        /// </summary>
        [EnumMember(Value = "automotive_services")]
        AutomotiveServices,

        /// <summary>
        /// Bakery.
        /// </summary>
        [EnumMember(Value = "bakery")]
        Bakery,

        /// <summary>
        /// BarClubLounge.
        /// </summary>
        [EnumMember(Value = "bar_club_lounge")]
        BarClubLounge,

        /// <summary>
        /// BeautySalon.
        /// </summary>
        [EnumMember(Value = "beauty_salon")]
        BeautySalon,

        /// <summary>
        /// BooksMagsMusicAndVideo.
        /// </summary>
        [EnumMember(Value = "books_mags_music_and_video")]
        BooksMagsMusicAndVideo,

        /// <summary>
        /// Bus.
        /// </summary>
        [EnumMember(Value = "bus")]
        Bus,

        /// <summary>
        /// CarRental.
        /// </summary>
        [EnumMember(Value = "car_rental")]
        CarRental,

        /// <summary>
        /// CareGiver.
        /// </summary>
        [EnumMember(Value = "care_giver")]
        CareGiver,

        /// <summary>
        /// CarpetCleaning.
        /// </summary>
        [EnumMember(Value = "carpet_cleaning")]
        CarpetCleaning,

        /// <summary>
        /// Caterer.
        /// </summary>
        [EnumMember(Value = "caterer")]
        Caterer,

        /// <summary>
        /// CharitableOrganization.
        /// </summary>
        [EnumMember(Value = "charitable_organization")]
        CharitableOrganization,

        /// <summary>
        /// ChildCare.
        /// </summary>
        [EnumMember(Value = "child_care")]
        ChildCare,

        /// <summary>
        /// Chiropractor.
        /// </summary>
        [EnumMember(Value = "chiropractor")]
        Chiropractor,

        /// <summary>
        /// CivicSocialAndFraternalAssociation.
        /// </summary>
        [EnumMember(Value = "civic_social_and_fraternal_association")]
        CivicSocialAndFraternalAssociation,

        /// <summary>
        /// Cleaning.
        /// </summary>
        [EnumMember(Value = "cleaning")]
        Cleaning,

        /// <summary>
        /// ClothingAlterations.
        /// </summary>
        [EnumMember(Value = "clothing_alterations")]
        ClothingAlterations,

        /// <summary>
        /// ClothingAndAccessories.
        /// </summary>
        [EnumMember(Value = "clothing_and_accessories")]
        ClothingAndAccessories,

        /// <summary>
        /// CoffeeTeaShop.
        /// </summary>
        [EnumMember(Value = "coffee_tea_shop")]
        CoffeeTeaShop,

        /// <summary>
        /// ComputerElectronicsAndApplianceRepair.
        /// </summary>
        [EnumMember(Value = "computer_electronics_and_appliance_repair")]
        ComputerElectronicsAndApplianceRepair,

        /// <summary>
        /// Consulting.
        /// </summary>
        [EnumMember(Value = "consulting")]
        Consulting,

        /// <summary>
        /// ConvenienceStore.
        /// </summary>
        [EnumMember(Value = "convenience_store")]
        ConvenienceStore,

        /// <summary>
        /// Delivery.
        /// </summary>
        [EnumMember(Value = "delivery")]
        Delivery,

        /// <summary>
        /// DentistOrthodontist.
        /// </summary>
        [EnumMember(Value = "dentist_orthodontist")]
        DentistOrthodontist,

        /// <summary>
        /// Design.
        /// </summary>
        [EnumMember(Value = "design")]
        Design,

        /// <summary>
        /// DryCleaningAndLaundry.
        /// </summary>
        [EnumMember(Value = "dry_cleaning_and_laundry")]
        DryCleaningAndLaundry,

        /// <summary>
        /// ElectricalServices.
        /// </summary>
        [EnumMember(Value = "electrical_services")]
        ElectricalServices,

        /// <summary>
        /// Electronics.
        /// </summary>
        [EnumMember(Value = "electronics")]
        Electronics,

        /// <summary>
        /// EventsFestivals.
        /// </summary>
        [EnumMember(Value = "events_festivals")]
        EventsFestivals,

        /// <summary>
        /// Eyewear.
        /// </summary>
        [EnumMember(Value = "eyewear")]
        Eyewear,

        /// <summary>
        /// Flooring.
        /// </summary>
        [EnumMember(Value = "flooring")]
        Flooring,

        /// <summary>
        /// FlowersAndGifts.
        /// </summary>
        [EnumMember(Value = "flowers_and_gifts")]
        FlowersAndGifts,

        /// <summary>
        /// FoodTruckCart.
        /// </summary>
        [EnumMember(Value = "food_truck_cart")]
        FoodTruckCart,

        /// <summary>
        /// FurnitureHomeGoods.
        /// </summary>
        [EnumMember(Value = "furniture_home_goods")]
        FurnitureHomeGoods,

        /// <summary>
        /// GeneralContracting.
        /// </summary>
        [EnumMember(Value = "general_contracting")]
        GeneralContracting,

        /// <summary>
        /// GroceryMarket.
        /// </summary>
        [EnumMember(Value = "grocery_market")]
        GroceryMarket,

        /// <summary>
        /// GymHealthClub.
        /// </summary>
        [EnumMember(Value = "gym_health_club")]
        GymHealthClub,

        /// <summary>
        /// HairSalonBarbershop.
        /// </summary>
        [EnumMember(Value = "hair_salon_barbershop")]
        HairSalonBarbershop,

        /// <summary>
        /// HardwareStore.
        /// </summary>
        [EnumMember(Value = "hardware_store")]
        HardwareStore,

        /// <summary>
        /// HeatingAndAirConditioning.
        /// </summary>
        [EnumMember(Value = "heating_and_air_conditioning")]
        HeatingAndAirConditioning,

        /// <summary>
        /// HobbyShop.
        /// </summary>
        [EnumMember(Value = "hobby_shop")]
        HobbyShop,

        /// <summary>
        /// IndependentStylistBarber.
        /// </summary>
        [EnumMember(Value = "independent_stylist_barber")]
        IndependentStylistBarber,

        /// <summary>
        /// InstallationServices.
        /// </summary>
        [EnumMember(Value = "installation_services")]
        InstallationServices,

        /// <summary>
        /// InstructorTeacher.
        /// </summary>
        [EnumMember(Value = "instructor_teacher")]
        InstructorTeacher,

        /// <summary>
        /// InteriorDesign.
        /// </summary>
        [EnumMember(Value = "interior_design")]
        InteriorDesign,

        /// <summary>
        /// JewelryAndWatches.
        /// </summary>
        [EnumMember(Value = "jewelry_and_watches")]
        JewelryAndWatches,

        /// <summary>
        /// JunkRemoval.
        /// </summary>
        [EnumMember(Value = "junk_removal")]
        JunkRemoval,

        /// <summary>
        /// Landscaping.
        /// </summary>
        [EnumMember(Value = "landscaping")]
        Landscaping,

        /// <summary>
        /// LegalServices.
        /// </summary>
        [EnumMember(Value = "legal_services")]
        LegalServices,

        /// <summary>
        /// Limousine.
        /// </summary>
        [EnumMember(Value = "limousine")]
        Limousine,

        /// <summary>
        /// LocksmithServices.
        /// </summary>
        [EnumMember(Value = "locksmith_services")]
        LocksmithServices,

        /// <summary>
        /// Lodging.
        /// </summary>
        [EnumMember(Value = "lodging")]
        Lodging,

        /// <summary>
        /// MarketingAdvertising.
        /// </summary>
        [EnumMember(Value = "marketing_advertising")]
        MarketingAdvertising,

        /// <summary>
        /// MassageTherapist.
        /// </summary>
        [EnumMember(Value = "massage_therapist")]
        MassageTherapist,

        /// <summary>
        /// MedicalPractitioner.
        /// </summary>
        [EnumMember(Value = "medical_practitioner")]
        MedicalPractitioner,

        /// <summary>
        /// MembershipOrganization.
        /// </summary>
        [EnumMember(Value = "membership_organization")]
        MembershipOrganization,

        /// <summary>
        /// MiscellaneousGoods.
        /// </summary>
        [EnumMember(Value = "miscellaneous_goods")]
        MiscellaneousGoods,

        /// <summary>
        /// MiscellaneousServices.
        /// </summary>
        [EnumMember(Value = "miscellaneous_services")]
        MiscellaneousServices,

        /// <summary>
        /// MoviesFilm.
        /// </summary>
        [EnumMember(Value = "movies_film")]
        MoviesFilm,

        /// <summary>
        /// Moving.
        /// </summary>
        [EnumMember(Value = "moving")]
        Moving,

        /// <summary>
        /// MuseumCultural.
        /// </summary>
        [EnumMember(Value = "museum_cultural")]
        MuseumCultural,

        /// <summary>
        /// Music.
        /// </summary>
        [EnumMember(Value = "music")]
        Music,

        /// <summary>
        /// NailSalon.
        /// </summary>
        [EnumMember(Value = "nail_salon")]
        NailSalon,

        /// <summary>
        /// NannyServices.
        /// </summary>
        [EnumMember(Value = "nanny_services")]
        NannyServices,

        /// <summary>
        /// NotaryServices.
        /// </summary>
        [EnumMember(Value = "notary_services")]
        NotaryServices,

        /// <summary>
        /// OfficeSupply.
        /// </summary>
        [EnumMember(Value = "office_supply")]
        OfficeSupply,

        /// <summary>
        /// OptometristLaserEyeSurgery.
        /// </summary>
        [EnumMember(Value = "optometrist_laser_eye_surgery")]
        OptometristLaserEyeSurgery,

        /// <summary>
        /// Other.
        /// </summary>
        [EnumMember(Value = "other")]
        Other,

        /// <summary>
        /// OutdoorMarkets.
        /// </summary>
        [EnumMember(Value = "outdoor_markets")]
        OutdoorMarkets,

        /// <summary>
        /// Painting.
        /// </summary>
        [EnumMember(Value = "painting")]
        Painting,

        /// <summary>
        /// PerformingArts.
        /// </summary>
        [EnumMember(Value = "performing_arts")]
        PerformingArts,

        /// <summary>
        /// PersonalTrainer.
        /// </summary>
        [EnumMember(Value = "personal_trainer")]
        PersonalTrainer,

        /// <summary>
        /// PestControl.
        /// </summary>
        [EnumMember(Value = "pest_control")]
        PestControl,

        /// <summary>
        /// PetStore.
        /// </summary>
        [EnumMember(Value = "pet_store")]
        PetStore,

        /// <summary>
        /// Photography.
        /// </summary>
        [EnumMember(Value = "photography")]
        Photography,

        /// <summary>
        /// Plumbing.
        /// </summary>
        [EnumMember(Value = "plumbing")]
        Plumbing,

        /// <summary>
        /// PoliticalOrganization.
        /// </summary>
        [EnumMember(Value = "political_organization")]
        PoliticalOrganization,

        /// <summary>
        /// PrintingServices.
        /// </summary>
        [EnumMember(Value = "printing_services")]
        PrintingServices,

        /// <summary>
        /// PrivateChef.
        /// </summary>
        [EnumMember(Value = "private_chef")]
        PrivateChef,

        /// <summary>
        /// PrivateShuttle.
        /// </summary>
        [EnumMember(Value = "private_shuttle")]
        PrivateShuttle,

        /// <summary>
        /// Psychiatrist.
        /// </summary>
        [EnumMember(Value = "psychiatrist")]
        Psychiatrist,

        /// <summary>
        /// QuickServiceRestaurant.
        /// </summary>
        [EnumMember(Value = "quick_service_restaurant")]
        QuickServiceRestaurant,

        /// <summary>
        /// RealEstate.
        /// </summary>
        [EnumMember(Value = "real_estate")]
        RealEstate,

        /// <summary>
        /// ReligiousOrganization.
        /// </summary>
        [EnumMember(Value = "religious_organization")]
        ReligiousOrganization,

        /// <summary>
        /// Roofing.
        /// </summary>
        [EnumMember(Value = "roofing")]
        Roofing,

        /// <summary>
        /// School.
        /// </summary>
        [EnumMember(Value = "school")]
        School,

        /// <summary>
        /// ShoeRepair.
        /// </summary>
        [EnumMember(Value = "shoe_repair")]
        ShoeRepair,

        /// <summary>
        /// SitDownRestaurant.
        /// </summary>
        [EnumMember(Value = "sit_down_restaurant")]
        SitDownRestaurant,

        /// <summary>
        /// SoftwareDevelopment.
        /// </summary>
        [EnumMember(Value = "software_development")]
        SoftwareDevelopment,

        /// <summary>
        /// Spa.
        /// </summary>
        [EnumMember(Value = "spa")]
        Spa,

        /// <summary>
        /// SpecialtyShop.
        /// </summary>
        [EnumMember(Value = "specialty_shop")]
        SpecialtyShop,

        /// <summary>
        /// SportingEvents.
        /// </summary>
        [EnumMember(Value = "sporting_events")]
        SportingEvents,

        /// <summary>
        /// SportingGoods.
        /// </summary>
        [EnumMember(Value = "sporting_goods")]
        SportingGoods,

        /// <summary>
        /// SportsRecreation.
        /// </summary>
        [EnumMember(Value = "sports_recreation")]
        SportsRecreation,

        /// <summary>
        /// TanningSalon.
        /// </summary>
        [EnumMember(Value = "tanning_salon")]
        TanningSalon,

        /// <summary>
        /// TattooPiercing.
        /// </summary>
        [EnumMember(Value = "tattoo_piercing")]
        TattooPiercing,

        /// <summary>
        /// Taxi.
        /// </summary>
        [EnumMember(Value = "taxi")]
        Taxi,

        /// <summary>
        /// Therapist.
        /// </summary>
        [EnumMember(Value = "therapist")]
        Therapist,

        /// <summary>
        /// Tourism.
        /// </summary>
        [EnumMember(Value = "tourism")]
        Tourism,

        /// <summary>
        /// TownCar.
        /// </summary>
        [EnumMember(Value = "town_car")]
        TownCar,

        /// <summary>
        /// Tutor.
        /// </summary>
        [EnumMember(Value = "tutor")]
        Tutor,

        /// <summary>
        /// VeterinaryServices.
        /// </summary>
        [EnumMember(Value = "veterinary_services")]
        VeterinaryServices,

        /// <summary>
        /// WatchJewelryRepair.
        /// </summary>
        [EnumMember(Value = "watch_jewelry_repair")]
        WatchJewelryRepair
    }
}