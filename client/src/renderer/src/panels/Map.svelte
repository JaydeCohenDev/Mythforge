<script lang="ts">
    import 'leaflet/dist/leaflet.css';
    import * as L from 'leaflet';
    import { mount, onMount } from 'svelte';
    import MapMarker from '../components/MapMarker.svelte';

    //import MapTexture from '../assets/images/map-generic.png';

    const { region } = $props();

    let map: L.Map | undefined;
    let markers: L.LayerGroup;
    let connections: L.LayerGroup;

    const getRoomMarkerKey = (roomName: string): string => {
        return `marker-${roomName}-pos`;
    };

    const getRoomLoc = (roomName: string): L.LatLngExpression => {
        const markerKey = getRoomMarkerKey(roomName);

        var markerLoc: L.LatLngExpression = [0, 0];
        const localMarkerLoc = window.localStorage.getItem(markerKey);
        if (localMarkerLoc) {
            const loc = JSON.parse(localMarkerLoc);
            markerLoc = [loc.x, loc.y];
        }

        return markerLoc;
    };

    onMount(() => {
        map = L.map('map', {
            crs: L.CRS.Simple,
            attributionControl: false,
            maxZoom: 2,
            zoomControl: false
        });
        markers = L.layerGroup().addTo(map);
        connections = L.layerGroup().addTo(map);

        map.on('zoomend', () => {});

        var bounds: L.LatLngBoundsExpression = [
            [0, 0],
            [1000, 1000]
        ];

        map.fitBounds(bounds);
    });

    const renderConnections = () => {
        connections.clearLayers();

        var uniqueLinks: Map<string, [string, string]> = new Map();

        for (var room of region.Rooms) {
            for (var exit of room.Exits) {
                const conId =
                    room.Id.localeCompare(exit) > 0 ? `${room.Id}-${exit}` : `${exit}-${room.Id}`;
                if (uniqueLinks.has(conId)) continue;
                uniqueLinks.set(conId, [room.Name, region.Rooms.find((r) => r.Id === exit).Name]);
            }
        }

        uniqueLinks.forEach((link) => {
            const fromPos = getRoomLoc(link[0]);
            const toPos = getRoomLoc(link[1]);

            L.polyline([fromPos, toPos], {}).addTo(connections);
        });
    };

    $effect(() => {
        if (region) {
            markers.clearLayers();

            let min: L.LatLngExpression = [0, 0];
            let max: L.LatLngExpression = [0, 0];

            for (var room of region.Rooms) {
                let markerLoc = getRoomLoc(room.Name);

                min[0] = Math.min(min[0], markerLoc[0]);
                min[1] = Math.min(min[1], markerLoc[1]);
                max[0] = Math.max(max[0], markerLoc[0]);
                max[1] = Math.max(max[1], markerLoc[1]);

                var marker = L.marker(markerLoc, {
                    title: room.Name,
                    icon: L.divIcon({
                        iconSize: [100, 100]
                    }),
                    draggable: true
                }).addTo(markers);

                marker.getElement().style.backgroundColor = 'transparent';
                marker.getElement().style.border = 'none';

                marker.on('dragend', (e) => {
                    console.log(e.target.options.title);
                    console.log(getRoomMarkerKey(e.target.options.title));
                    window.localStorage.setItem(
                        getRoomMarkerKey(e.target.options.title),
                        JSON.stringify({
                            x: e.target._latlng.lat,
                            y: e.target._latlng.lng
                        })
                    );
                    renderConnections();
                });

                mount(MapMarker, {
                    target: marker.getElement(),
                    props: {
                        room: room
                    }
                });
            }

            renderConnections();

            map.fitBounds([min, max], {
                padding: [100, 100],
                animate: false
            });
        }
    });
</script>

<div id="map">
    <div class="overlay"><h1 style="margin-left: auto">{region ? region.Name : ''}</h1></div>
</div>

<style>
    #map {
        width: 100vw;
        height: 100vh;
        background-color: #111;
    }
    .overlay {
        position: absolute;
        left: 0;
        top: 0;
        width: calc(100% - 40px);
        height: calc(100% - 40px);
        padding: 20px;
        display: flex;
        z-index: 1000;

        color: white;
        text-shadow: 0px 0px 10px black;

        pointer-events: none;
    }
</style>
