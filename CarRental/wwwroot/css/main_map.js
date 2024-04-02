
const apiKey = "AAPKc02e0f74368d486aae1c67bcb1750c7aiDlJAfqPWDUCEinTR9M-Z5O3HRdmOfbGr5RZ9Xx9a2d0m5fgv4KNyolJkBYBC3gI";

const map = new ol.Map({
    target: "map"

});

map.setView(
    new ol.View({
        center: ol.proj.fromLonLat([106.0962303, 11.3138184]),
        zoom: 10
    })
);


var style = new ol.style.Style({
    image: new ol.style.Circle({
        radius: 7,
        stroke: new ol.style.Stroke({
            color: 'rgba(200,200,200,1.0)',
            width: 3
        }),
        fill: new ol.style.Fill({
            color: 'green'
        })
    }),
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});
var style_basic = new ol.style.Style({   
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});
var styleF_basic = function (feature) {
    style_basic.getText().setText(feature.get('name'));
    return style_basic;
}

var vectorsource_basic = new ol.source.Vector({
    format: new ol.format.GeoJSON()
});

var layer_basic = new ol.layer.Vector({
    source: vectorsource_basic,
    style: styleF_basic
});

var iconFeature_basics = [];
var icon_HOANGSA = new ol.Feature({
    geometry: new ol.geom.Point(ol.proj.transform([111.63530962513813, 16.244316130142195], 'EPSG:4326', 'EPSG:3857')),
    population: 4000,
    rainfall: 500
});
var icon_TRUONGSA = new ol.Feature({
    geometry: new ol.geom.Point(ol.proj.transform([114.64927384286665, 10.46698953676183], 'EPSG:4326', 'EPSG:3857')),
    population: 4000,
    rainfall: 500
});

icon_HOANGSA.set('name', "HOÀNG SA");
icon_TRUONGSA.set('name', "TRƯỜNG SA");
iconFeature_basics.push(icon_HOANGSA);
iconFeature_basics.push(icon_TRUONGSA);
vectorsource_basic.addFeatures(iconFeature_basics);

var style_1 = new ol.style.Style({
    image: new ol.style.Circle({
        radius: 7,
        stroke: new ol.style.Stroke({
            color: 'rgba(200,200,200,1.0)',
            width: 3
        }),
        fill: new ol.style.Fill({
            color: 'green'
        })
    }),
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});

var style_2 = new ol.style.Style({
    image: new ol.style.Circle({
        radius: 7,
        stroke: new ol.style.Stroke({
            color: 'rgba(200,200,200,1.0)',
            width: 3
        }),
        fill: new ol.style.Fill({
            color: 'darkred'
        })
    }),
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});

var style_3 = new ol.style.Style({
    image: new ol.style.Circle({
        radius: 7,
        stroke: new ol.style.Stroke({
            color: 'rgba(200,200,200,1.0)',
            width: 3
        }),
        fill: new ol.style.Fill({
            color: 'darkgreen'
        })
    }),
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});

var style_4 = new ol.style.Style({
    image: new ol.style.Circle({
        radius: 7,
        stroke: new ol.style.Stroke({
            color: 'rgba(200,200,200,1.0)',
            width: 3
        }),
        fill: new ol.style.Fill({
            color: 'darkred'
        })
    }),
    text: new ol.style.Text({
        font: 'bold 11px "Open Sans", "Arial Unicode MS", "sans-serif"',
        textAlign: "left",
        offsetX: 15,
        placement: 'point',
        fill: new ol.style.Fill({ color: 'blue' })
    }),
});

var styleF1 = function (feature) {
    style_1.getText().setText(feature.get('name'));
    return style_1;
}
var styleF2 = function (feature) {
    style_2.getText().setText(feature.get('name'));
    return style_2;
}
var styleF3 = function (feature) {
    style_3.getText().setText(feature.get('name'));
    return style_3;
}
var styleF4 = function (feature) {
    style_4.getText().setText(feature.get('name'));
    return style_4;
}

var styleFunction = function (feature) {
    style.getText().setText(feature.get('name'));
    return style;
}
var vectorsource_layer1_1 = new ol.source.Vector({
    format: new ol.format.GeoJSON()
});

var layer_1 = new ol.layer.Vector({
    source: vectorsource_layer1_1,
    style: styleF1
});

var vectorsource_layer2_1 = new ol.source.Vector({
    format: new ol.format.GeoJSON()
});

var layer_2 = new ol.layer.Vector({
    source: vectorsource_layer2_1,
    style: styleF2
});



const setBasemap = (name_map, results, status) => {

    vectorsource_basic = new ol.source.Vector({
        format: new ol.format.GeoJSON()
    });

    layer_basic = new ol.layer.Vector({
        source: vectorsource_basic,
        style: styleF_basic
    });

    vectorsource_basic.addFeatures(iconFeature_basics);

    if (!status) {
        vectorsource_layer1_1 = new ol.source.Vector({
            format: new ol.format.GeoJSON()
        });
        layer_1 = new ol.layer.Vector({
            source: vectorsource_layer1_1,
            style: styleF1
        });

        vectorsource_layer2_1 = new ol.source.Vector({
            format: new ol.format.GeoJSON()
        });

        layer_2 = new ol.layer.Vector({
            source: vectorsource_layer2_1,
            style: styleF2
        });

        var iconFeatures_layer1 = [];
        var iconFeatures_layer2 = [];
        var iconFeatures_layer3 = [];
        var iconFeatures_layer4 = [];
        var iconFeatures_layer5 = [];        
        
        if (_results === "") {                       
            $.ajax({
                type: "GET",                
                url: "../MAP/GET_TBL_US_CANG_BEN",               
                success: function (data) {
                    //console.log(data);
                    var _objs = JSON.parse(data);
                    var _obj = _objs[0];
                    var _features = _obj["features"];

                    var _i;
                    for (_i = 0; _i < _features.length; _i++) {
                        var _properties = _features[_i]["properties"];
                        var _geometry = _features[_i]["geometry"];
                        var _lat = _geometry["coordinates"][0];
                        var _lon = _geometry["coordinates"][1];

                        var iconFeature = new ol.Feature({
                            geometry: new ol.geom.Point(ol.proj.transform([_lat, _lon], 'EPSG:4326', 'EPSG:3857')),
                            population: 4000,
                            rainfall: 500
                        });
                        iconFeature.set('name', _properties["TENBEN"]);
                        iconFeature.set('address_1', _properties["DIACHILIENHE"]);
                        var _IDTRANGTHAI = _properties["IDTRANGTHAI"];

                        var _IDTRANGTHAI = _properties["IDTRANGTHAI"];
                        var _TENTRANGTHAI = _properties["TENTRANGTHAI"];
                        var _TENCHUBEN = _properties["TENCHUBEN"];
                        var _DIACHIBEN = _properties["DIACHIBEN"];
                        var _LAT_VITRI = _properties["LAT_VITRI"];
                        var _LON_VITRI = _properties["LON_VITRI"];
                        var _HINHCANGBEN1 = _properties["HINHCANGBEN1"];
                        var _HINHCANGBEN2 = _properties["HINHCANGBEN2"];
                        var _THOIGIANHOATDONG = _properties["THOIGIANHOATDONG"];
                        var _NGAYCAPLANDAU = _properties["NGAYCAPLANDAU"];
                        var _MUCDICHSUDUNG = _properties["MUCDICHSUDUNG"];
                        var _TENLOAIBO = _properties["TENLOAIBO"];
                        var _TENTUYENSONG = _properties["TENTUYENSONG"];

                        iconFeature.set('name', _properties["TENBEN"]);
                        iconFeature.set('address_1', _properties["DIACHILIENHE"]);
                        iconFeature.set('TENTRANGTHAI', _TENTRANGTHAI);
                        iconFeature.set('TENCHUBEN', _TENCHUBEN);
                        iconFeature.set('DIACHIBEN', _DIACHIBEN);
                        iconFeature.set('LAT_VITRI', _LAT_VITRI);
                        iconFeature.set('LON_VITRI', _LON_VITRI);
                        iconFeature.set('HINHCANGBEN1', _HINHCANGBEN1);
                        iconFeature.set('HINHCANGBEN2', _HINHCANGBEN2);
                        iconFeature.set('THOIGIANHOATDONG', _THOIGIANHOATDONG);
                        iconFeature.set('NGAYCAPLANDAU', _NGAYCAPLANDAU);
                        iconFeature.set('MUCDICHSUDUNG', _MUCDICHSUDUNG);
                        iconFeature.set('TENLOAIBO', _TENLOAIBO);
                        iconFeature.set('TENTUYENSONG', _TENTUYENSONG);

                        console.log(_TENCHUBEN);

                        if (_IDTRANGTHAI === "2")
                            iconFeatures_layer1.push(iconFeature);
                        else
                            iconFeatures_layer2.push(iconFeature);
                       
                    }
                    vectorsource_layer1_1.addFeatures(iconFeatures_layer1);
                    vectorsource_layer2_1.addFeatures(iconFeatures_layer2);
                    
                }
            });
        }
        else {
            var iconFeatures_layer1 = [];
            var iconFeatures_layer2 = [];
            var iconFeatures_layer3 = [];
            var iconFeatures_layer4 = [];
            var iconFeatures_layer5 = [];   
            var _objs = JSON.parse(results);
            var _obj = _objs[0];
            var _features = _obj["features"];
            var _i;
            for (_i = 0; _i < _features.length; _i++) {
                var _properties = _features[_i]["properties"];
                var _geometry = _features[_i]["geometry"];
                var _lat = _geometry["coordinates"][0];
                var _lon = _geometry["coordinates"][1];

                var iconFeature = new ol.Feature({
                    geometry: new ol.geom.Point(ol.proj.transform([_lat, _lon], 'EPSG:4326', 'EPSG:3857')),
                    population: 4000,
                    rainfall: 500
                });
                iconFeature.set('name', _properties["TENBEN"])
                iconFeature.set('address_1', _properties["DIACHILIENHE"])
                var _IDTRANGTHAI = _properties["IDTRANGTHAI"];
                var _IDTRANGTHAI = _properties["IDTRANGTHAI"];
                var _TENTRANGTHAI = _properties["TENTRANGTHAI"];
                var _TENCHUBEN = _properties["TENCHUBEN"];
                var _DIACHIBEN = _properties["DIACHIBEN"];
                var _LAT_VITRI = _properties["LAT_VITRI"];
                var _LON_VITRI = _properties["LON_VITRI"];
                var _HINHCANGBEN1 = _properties["HINHCANGBEN1"];
                var _HINHCANGBEN2 = _properties["HINHCANGBEN2"];
                var _THOIGIANHOATDONG = _properties["THOIGIANHOATDONG"];
                var _NGAYCAPLANDAU = _properties["NGAYCAPLANDAU"];
                var _MUCDICHSUDUNG = _properties["MUCDICHSUDUNG"];
                var _TENLOAIBO = _properties["TENLOAIBO"];
                var _TENTUYENSONG = _properties["TENTUYENSONG"];

                iconFeature.set('name', _properties["TENBEN"]);
                iconFeature.set('address_1', _properties["DIACHILIENHE"]);
                iconFeature.set('TENTRANGTHAI', _TENTRANGTHAI);
                iconFeature.set('TENCHUBEN', _TENCHUBEN);
                iconFeature.set('DIACHIBEN', _DIACHIBEN);
                iconFeature.set('LAT_VITRI', _LAT_VITRI);
                iconFeature.set('LON_VITRI', _LON_VITRI);                
                iconFeature.set('HINHCANGBEN1', _HINHCANGBEN1);
                iconFeature.set('HINHCANGBEN2', _HINHCANGBEN2);
                iconFeature.set('THOIGIANHOATDONG', _THOIGIANHOATDONG);
                iconFeature.set('NGAYCAPLANDAU', _NGAYCAPLANDAU);
                iconFeature.set('MUCDICHSUDUNG', _MUCDICHSUDUNG);
                iconFeature.set('TENLOAIBO', _TENLOAIBO);
                iconFeature.set('TENTUYENSONG', _TENTUYENSONG);

                console.log(_TENCHUBEN);

                if (_IDTRANGTHAI === "2")
                    iconFeatures_layer1.push(iconFeature);
                else
                    iconFeatures_layer2.push(iconFeature);

            }
            vectorsource_layer1_1.addFeatures(iconFeatures_layer1);
            vectorsource_layer2_1.addFeatures(iconFeatures_layer2);          

        }

    }
    else {

        
        var features_layer1 = layer_1.getSource().getFeatures();
        features_layer1.forEach((feature) => {
            layer_1.getSource().removeFeature(feature);
        });

        var features_layer2 = layer_2.getSource().getFeatures();
        features_layer2.forEach((feature) => {
            layer_2.getSource().removeFeature(feature);
        });
        

        var iconFeatures_layer1 = [];
        var iconFeatures_layer2 = [];
        var iconFeatures_layer3 = [];
        var iconFeatures_layer4 = [];
        var iconFeatures_layer5 = []; 

        var _objs = JSON.parse(results);
        var _obj = _objs[0];
        var _features = _obj["features"];
        var _i;
        for (_i = 0; _i < _features.length; _i++) {
            var _properties = _features[_i]["properties"];
            var _geometry = _features[_i]["geometry"];
            var _lat = _geometry["coordinates"][0];
            var _lon = _geometry["coordinates"][1];

            var iconFeature = new ol.Feature({
                geometry: new ol.geom.Point(ol.proj.transform([_lat, _lon], 'EPSG:4326', 'EPSG:3857')),
                population: 4000,
                rainfall: 500
            });
            

            var _IDTRANGTHAI = _properties["IDTRANGTHAI"];
            var _TENTRANGTHAI = _properties["TENTRANGTHAI"];
            var _TENCHUBEN = _properties["TENCHUBEN"];
            var _DIACHIBEN = _properties["DIACHIBEN"];
            var _LAT_VITRI = _properties["LAT_VITRI"];
            var _LON_VITRI = _properties["LON_VITRI"];
            var _HINHCANGBEN1 = _properties["HINHCANGBEN1"];
            var _HINHCANGBEN2 = _properties["HINHCANGBEN2"];
            var _THOIGIANHOATDONG = _properties["THOIGIANHOATDONG"];
            var _NGAYCAPLANDAU = _properties["NGAYCAPLANDAU"];
            var _MUCDICHSUDUNG = _properties["MUCDICHSUDUNG"];
            var _TENLOAIBO = _properties["TENLOAIBO"];
            var _TENTUYENSONG = _properties["TENTUYENSONG"];

            iconFeature.set('name', _properties["TENBEN"]);
            iconFeature.set('address_1', _properties["DIACHILIENHE"]);
            iconFeature.set('TENTRANGTHAI', _TENTRANGTHAI);
            iconFeature.set('TENCHUBEN', _TENCHUBEN);
            iconFeature.set('DIACHIBEN', _DIACHIBEN);
            iconFeature.set('LAT_VITRI', _LAT_VITRI);
            iconFeature.set('LON_VITRI', _LON_VITRI);
            iconFeature.set('HINHCANGBEN1', _HINHCANGBEN1);
            iconFeature.set('HINHCANGBEN2', _HINHCANGBEN2);
            iconFeature.set('THOIGIANHOATDONG', _THOIGIANHOATDONG);
            iconFeature.set('NGAYCAPLANDAU', _NGAYCAPLANDAU);
            iconFeature.set('MUCDICHSUDUNG', _MUCDICHSUDUNG);
            iconFeature.set('TENLOAIBO', _TENLOAIBO);
            iconFeature.set('TENTUYENSONG', _TENTUYENSONG);

            console.log(_TENCHUBEN);

            if (_IDTRANGTHAI === "2")
                iconFeatures_layer1.push(iconFeature);
            else
                iconFeatures_layer2.push(iconFeature);

        }
        vectorsource_layer1_1.addFeatures(iconFeatures_layer1);
        vectorsource_layer2_1.addFeatures(iconFeatures_layer2);       

    }

    //arcgis - street
    //6976148c11bd497d8624206f9ee03e30

    olms(map, "https://basemaps-api.arcgis.com/arcgis/rest/services/styles/" + name_map + "?type=style&token=" + apiKey)
        .then(function (map) {
            map.addLayer(layer_1);
            map.addLayer(layer_2);    
            map.addLayer(layer_basic);    
        });

    const popup = new Popup();

    map.addOverlay(popup);

    map.on("click", (event) => {
        const traillayer1 = map.getFeaturesAtPixel(event.pixel, {
            layerFilter: layer => layer === layer_1
        });
        const traillayer2 = map.getFeaturesAtPixel(event.pixel, {
            layerFilter: layer => layer === layer_2
        });

        if (traillayer1.length > 0) {
            const _IDTRANGTHAI = traillayer1[0].get('IDTRANGTHAI');
            const _TENTRANGTHAI = traillayer1[0].get('TENTRANGTHAI');
            const _TENCHUBEN = traillayer1[0].get('TENCHUBEN');
            const _DIACHIBEN = traillayer1[0].get('DIACHIBEN');
            const _LAT_VITRI = traillayer1[0].get('LAT_VITRI');
            const _LON_VITRI = traillayer1[0].get('LON_VITRI');
            const _HINHCANGBEN1 = traillayer1[0].get('HINHCANGBEN1');
            const _HINHCANGBEN2 = traillayer1[0].get('HINHCANGBEN2');
            const _THOIGIANHOATDONG = traillayer1[0].get('THOIGIANHOATDONG');
            const _NGAYCAPLANDAU = traillayer1[0].get('NGAYCAPLANDAU');
            const _MUCDICHSUDUNG = traillayer1[0].get('MUCDICHSUDUNG');
            const _TENLOAIBO = traillayer1[0].get('TENLOAIBO');
            const _TENTUYENSONG = traillayer1[0].get('TENTUYENSONG');
            const _TENBEN = traillayer1[0].get('name');
            popup.show(event.coordinate, `<span style="color: green;"><b>${_TENBEN}</b></span></br>Tên chủ bến: <b> ${_TENCHUBEN}</b></br>Địa chỉ: <b>${_DIACHIBEN}</b></br>Tuyến sông: <b>${_TENTUYENSONG}</b></br>Bờ: <b>${_TENLOAIBO}</b></br>Tọa độ: <i>(${_LAT_VITRI},${_LON_VITRI})</i></br>Hình đại diện: <div class="row"><div class="col-md-6"><img style="width: 250px" src="${_HINHCANGBEN1}" /></div></div></br>Thời hạn hoạt động: <i>${_THOIGIANHOATDONG}</i></br>Ngày cấp lần đầu: <b>${_NGAYCAPLANDAU}</b></br>Mục đích sử dụng: <b> ${_MUCDICHSUDUNG}</b>`);
        } else if (traillayer2.length > 0) {
            const _IDTRANGTHAI = traillayer2[0].get('IDTRANGTHAI');
            const _TENTRANGTHAI = traillayer2[0].get('TENTRANGTHAI');
            const _TENCHUBEN = traillayer2[0].get('TENCHUBEN');
            const _DIACHIBEN = traillayer2[0].get('DIACHIBEN');
            const _LAT_VITRI = traillayer2[0].get('LAT_VITRI');
            const _LON_VITRI = traillayer2[0].get('LON_VITRI');
            const _HINHCANGBEN1 = traillayer2[0].get('HINHCANGBEN1');
            const _HINHCANGBEN2 = traillayer2[0].get('HINHCANGBEN2');
            const _THOIGIANHOATDONG = traillayer2[0].get('THOIGIANHOATDONG');
            const _NGAYCAPLANDAU = traillayer2[0].get('NGAYCAPLANDAU');
            const _MUCDICHSUDUNG = traillayer2[0].get('MUCDICHSUDUNG');
            const _TENBEN = traillayer2[0].get('name');
            const _TENLOAIBO = traillayer2[0].get('TENLOAIBO');
            const _TENTUYENSONG = traillayer2[0].get('TENTUYENSONG');
           // popup.show(event.coordinate, `<span style="color: darkred;"><b>${_TENBEN}</b></span></br>Tên chủ bến: <b> ${_TENCHUBEN}</b></br>Địa chỉ: <b>${_DIACHIBEN}</b></br>Tọa độ: <i>(${_LAT_VITRI},${_LON_VITRI})</i></br>Hình đại diện: <div class="row"><div class="col-md-6"><img src="${_HINHCANGBEN1}" /></div></div></br>Thời hạn hoạt động: <i>${_THOIGIANHOATDONG}</i></br>Ngày cấp lần đầu: <b>${_NGAYCAPLANDAU}</b></br>Mục đích sử dụng: <b> ${_MUCDICHSUDUNG}</b>`);
            popup.show(event.coordinate, `<span style="color: green;"><b>${_TENBEN}</b></span></br>Tên chủ bến: <b> ${_TENCHUBEN}</b></br>Địa chỉ: <b>${_DIACHIBEN}</b></br>Tuyến sông: <b>${_TENTUYENSONG}</b></br>Bờ: <b>${_TENLOAIBO}</b></br>Tọa độ: <i>(${_LAT_VITRI},${_LON_VITRI})</i></br>Hình đại diện: <div class="row"><div class="col-md-6"><img style="width: 250px" src="${_HINHCANGBEN1}" /></div></div></br>Thời hạn hoạt động: <i>${_THOIGIANHOATDONG}</i></br>Ngày cấp lần đầu: <b>${_NGAYCAPLANDAU}</b></br>Mục đích sử dụng: <b> ${_MUCDICHSUDUNG}</b>`);
        }
        else {
            popup.hide();
        }
    });

};

const basemapsSelectElement = document.querySelector('#basemaps');

basemapsSelectElement.addEventListener('change', (e) => {
    setBasemap(e.target.value, _results, false);
});











